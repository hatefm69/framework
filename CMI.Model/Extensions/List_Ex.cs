namespace CMI.Model.Extensions
{
    public static class List_Ex
    {
        public static List<T> Search<T>(this List<T> entityList, List<string> columnList, string searchCharacter)
        {
            if (string.IsNullOrEmpty(searchCharacter))
                return entityList;

            columnList = columnList.Select(c => c.ToLower()).ToList();

            var properties = typeof(T).GetProperties().Where(p => columnList.Contains(p.Name.ToLower())).ToList();
            var searchListResult = new List<T>();
            foreach (var property in properties)
            {
                var result = entityList.Where(entity => property.GetValue(entity).ToString().Contains(searchCharacter)).ToList();

                if (result.Count > 0)
                {
                    var notExistResult = result.Except(searchListResult).ToList();

                    if (notExistResult.Any())
                        searchListResult.AddRange(notExistResult);
                }
            }

            return searchListResult;
        }
    }
}

