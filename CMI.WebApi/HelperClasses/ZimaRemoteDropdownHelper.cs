namespace CMI.WebApi.HelperClasses
{
    public class ZimaRemoteDropdownHelper
    {
        public static List<ZimaRemoteDropDown> GetYears(List<ZimaRemoteDropDown> zimaRemoteDropDownList, List<ZimaDropDownItem> yearsList, string name)
        {
            var zimaRemoteDropDownItems = new List<ZimaRemoteDropDownItem>();
            foreach (var item in yearsList)
            {
                zimaRemoteDropDownItems.Add(new ZimaRemoteDropDownItem
                {
                    Title = item.Title,
                    Value = item.Value
                });
            }

            zimaRemoteDropDownList.Add(new ZimaRemoteDropDown
            {
                Name = name,
                Value = zimaRemoteDropDownItems.ToArray()
            });

            return zimaRemoteDropDownList;
        }
    }
}
