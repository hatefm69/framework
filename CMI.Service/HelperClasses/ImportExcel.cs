using AutoMapper.Internal;
using ClosedXML.Excel;

namespace CMI.Service.HelperClasses
{
    public static class ImportExcel
    {
        public static List<T> GetData<T>(this IFormFileCollection files) where T : new()
        {
            if (files == null || files.Count <= 0)
                throw new InformationException("هیچ فایلی ارسال نشده است");
            if (files.Count > 1)
                throw new InformationException("حداکثر یک فایل انتخاب نمایید");
            List<T> data = new List<T>();
            using var stream = new MemoryStream();
            files[0].CopyTo(stream);
            using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1) ?? throw new InformationException("هیچ شیتی در فایل اکسل پیدا نشد");
            foreach (var row in worksheet.RangeUsed().RowsUsed())
            {
                if (worksheet.LastRowUsed().RowNumber() <= 1)
                    throw new InformationException($"دانش آموزی در فایل اکسل درج نکرده اید");
                var columns = typeof(T).GetProperties().Select(z => new { Name = z.Name, Description = z.Attributes.GetDescription(), Type = z.GetMemberType() });

                //var columns = new List<string>(){
                //    "نام","نام خانوادگی","پایه","شهر","وضعیت","تاریخ تولد","خویشاوندان"
                //};
                // سطر اول یعنی سر ستونها
                if (row.RowNumber() == 1)
                {

                    var index = 0;
                    if (columns.Count() == row.Cells().Count())
                    {
                        throw new InformationException("سر ستونها با سر ستون های مدل پیش فرض همخوانی ندارد." + "\n" + string.Join("\n", columns));
                    }
                    foreach (var cell in row.Cells())
                    {
                        ++index;
                        if (columns.Select(x => x.Name).ToList().IndexOf(cell.Value.ToString()) == index)
                            throw new InformationException(columns.Select(z => z.Name).ToArray()[index]);
                    }
                    continue; // برای خواندن دیتا از سطر دوم شروع کن
                }
                // سطرهای 2 به بعد
                var student = new T();
                foreach (var cell in row.Cells())
                {
                    var title = columns.Select(x => x.Name).ToArray()[cell.Address.ColumnNumber];
                    var index = columns.Select(z => z.Name).ToList().IndexOf(title);
                    var column = columns.ToArray()[index - 1];

                    var rownumber = row.Cells().ToList().IndexOf(cell);
                    if (string.IsNullOrEmpty(cell.Value.ToString()))
                        throw new InformationException($@"در سطر {rownumber} ستون {column.Name} خالی هست");
                    if (column.Type == typeof(int))
                    {
                        if (int.TryParse(cell.Value.ToString(), out int intCode) == false)
                            throw new InformationException($"در سطر {rownumber} ستون {column.Name} عدد معتبر نیست");

                        var errorColumn = typeof(T).GetProperties().Where(z => z.Name == title).Select(z => new { Name = z.Name, Description = z.Attributes.GetDescription() });

                        if (int.TryParse(cell.Value.ToString(), out int intCodeMinMaxValue) == true && (intCodeMinMaxValue > 999999 || intCodeMinMaxValue < 1))
                            throw new InformationException($"در سطر {rownumber} ستون {column.Name} : {errorColumn}");

                        student.GetType().SetMemberValue(column.Name, int.Parse(cell.Value.ToString()));

                    }
                    if (column.Type == typeof(bool?) || column.Type == typeof(bool))
                    {
                        if (bool.TryParse(cell.Value.ToString(), out bool boolCode) == false)
                        {
                            if (cell.Value.ToString() == "غیر فعال")
                                boolCode = false;
                            else
                            if (cell.Value.ToString() == "فعال")
                                boolCode = true;
                            else
                                throw new InformationException($"در سطر {rownumber} ستون {column.Name} عدد معتبر نیست");
                        }

                        var errorColumn = typeof(T).GetProperties().Where(z => z.Name == title).Select(z => new { Name = z.Name, Description = z.Attributes.GetDescription() });

                        student.GetType().GetProperty(column.Name).SetValue(student, boolCode);


                    }
                    else
                    {
                        student.GetType().GetProperty(column.Name).SetValue(student, cell.Value.ToString());

                    }



                }
                data.Add(student);
            }



            return data;


        }
    }

}
