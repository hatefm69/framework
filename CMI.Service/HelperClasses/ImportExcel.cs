using AutoMapper.Internal;
using ClosedXML.Excel;
using System.ComponentModel;
using System.Reflection;

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
                var columns = typeof(T).GetProperties().Select(z => new
                {
                    Name = z.Name,
                    Description = z.GetCustomAttribute<DescriptionAttribute>()?.Description
                    ,
                    Type = z.GetMemberType()
                });

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
                        if (columns.Select(x => x.Description).ToList().IndexOf(cell.Value.ToString()) == index)
                            throw new InformationException(columns.Select(z => z.Description).ToArray()[index]);
                    }
                    continue; // برای خواندن دیتا از سطر دوم شروع کن
                }
                // سطرهای 2 به بعد
                var student = new T();
                foreach (var cell in row.Cells())
                {
                    var title = columns.Select(x => x.Description).ToArray()[cell.Address.ColumnNumber];
                    var index = columns.Select(z => z.Description).ToList().IndexOf(title);
                    var column = columns.ToArray()[index - 1];

                    var rownumber = row.Cells().ToList().IndexOf(cell);
                    if (string.IsNullOrEmpty(cell.Value.ToString()))
                        throw new InformationException($@"در سطر {rownumber} ستون {column.Description} خالی هست");
                    if (column.Type == typeof(int?) || column.Type == typeof(int))
                    {
                        if (column.Type.IsNullableType())
                        {
                            if (int.TryParse(cell.Value.ToString(), out int intCode) == false)
                                throw new InformationException($"در سطر {rownumber} ستون {column.Description} عدد معتبر نیست");

                            var errorColumn = typeof(T).GetProperties().Where(z => z.GetCustomAttribute<DescriptionAttribute>()?.Description == title).Select(z => new { Name = z.Name, Description = z.Attributes.GetDescription() });

                            if (int.TryParse(cell.Value.ToString(), out int intCodeMinMaxValue) == true && (intCodeMinMaxValue > 999999 || intCodeMinMaxValue < 1))
                                throw new InformationException($"در سطر {rownumber} ستون {column.Description} : {errorColumn}");

                            student.GetType().SetMemberValue(column.Name, int.Parse(cell.Value.ToString()));
                        }
                    }
                    if (column.Type == typeof(bool?) || column.Type == typeof(bool))
                    {
                        if (column.Type.IsNullableType())
                        {
                            if (bool.TryParse(cell.Value.ToString(), out bool boolCode) == false)
                            {
                                if (cell.Value.ToString() == "غیر فعال" || cell.Value.ToString() == "نه" || cell.Value.ToString() == "false" || cell.Value.ToString() == "0")
                                    boolCode = false;
                                else
                                if (cell.Value.ToString() == "فعال" || cell.Value.ToString() == "آری" || cell.Value.ToString() == "اری" || cell.Value.ToString() == "true" || cell.Value.ToString() == "1")
                                    boolCode = true;
                                else
                                    throw new InformationException($"در سطر {rownumber} ستون {column.Description} عدد معتبر نیست");
                            }
                            student.GetType().GetProperty(column.Name).SetValue(student, boolCode);
                        }
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
        public static List<T> GetData<T>(this XLWorkbook workbook) where T : new()
        {
            List<T> data = new List<T>();
            //using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1) ?? throw new InformationException("هیچ شیتی در فایل اکسل پیدا نشد");
            if (worksheet.LastRowUsed().RowNumber() <= 1)
                throw new InformationException($"دانش آموزی در فایل اکسل درج نکرده اید");

            var columns = typeof(T).GetProperties().Select(z => new { Name = z.Name, Description = z.GetCustomAttribute<DescriptionAttribute>()?.Description, Type = z.GetMemberType() });
            foreach (var row in worksheet.RangeUsed().RowsUsed())
            {
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


                        if (columns.Select(x => x.Description).ToList().IndexOf(cell.Value.ToString()) != index)
                            throw new InformationException(columns.Select(z => z.Description).ToArray()[index]);
                        ++index;
                    }
                    continue; // برای خواندن دیتا از سطر دوم شروع کن
                }
                // سطرهای 2 به بعد
                var student = new T();
                foreach (var cell in row.Cells())
                {
                    var title = columns.Select(x => x.Description).ToArray()[cell.Address.ColumnNumber];
                    var index = columns.Select(z => z.Description).ToList().IndexOf(title);
                    var column = columns.ToArray()[index - 1];

                    var rownumber = row.Cells().ToList().IndexOf(cell);

                    if (string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        if (!column.Type.IsNullableType() && column.Type != typeof(string))
                            throw new InformationException($@"در سطر {rownumber} ستون {column.Description} خالی هست");
                        else
                        {
                            student.GetType().GetProperty(column.Name).SetValue(student, null);
                            continue;
                        }
                    }

                    if (column.Type == typeof(int?) || column.Type == typeof(int))
                    {

                        if (int.TryParse(cell.Value.ToString(), out int intCode) == false)
                            throw new InformationException($"در سطر {rownumber} ستون {column.Description} عدد معتبر نیست");

                        if (int.TryParse(cell.Value.ToString(), out int intCodeMinMaxValue) == true && (intCodeMinMaxValue > 999999 || intCodeMinMaxValue < 1))
                            throw new InformationException($"در سطر {rownumber} ستون {column.Description} : {column.Description}");

                        student.GetType().GetProperty(column.Name).SetValue(student, intCodeMinMaxValue);

                    }
                    if (column.Type == typeof(bool?) || column.Type == typeof(bool))
                    {

                        if (bool.TryParse(cell.Value.ToString(), out bool boolCode) == false)
                        {
                            if (cell.Value.ToString() == "غیر فعال" || cell.Value.ToString() == "نه" || cell.Value.ToString() == "false" || cell.Value.ToString() == "0")
                                boolCode = false;
                            else
                            if (cell.Value.ToString() == "فعال" || cell.Value.ToString() == "آری" || cell.Value.ToString() == "اری" || cell.Value.ToString() == "true" || cell.Value.ToString() == "1")
                                boolCode = true;
                            else
                                throw new InformationException($"در سطر {rownumber} ستون {column.Description} عدد معتبر نیست");
                        }
                        student.GetType().GetProperty(column.Name).SetValue(student, boolCode);

                    }
                    else if (column.Type == typeof(string))
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
