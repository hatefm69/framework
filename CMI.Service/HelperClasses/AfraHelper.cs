using FIS.AfraServices.Models;

namespace CMI.Service.HelperClasses
{
    public class AfraHelper
    {
        #region Public Functions

        public static Position Position_FindByCode(string searchText)
        {
            var position = ExternalServices.GetAfra().Position_FindByCode(searchText);
            var result = ServiceBusResult.Validate(position);
            return result != null ? GetPosition(result) : null;
        }

        public static List<Position> Position_FindByName(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return new List<Position>();

            var position = ExternalServices.GetAfra().Position_FindByName(searchText);
            var result = ServiceBusResult.Validate(position);
            return result?.Select(GetPosition).ToList() ?? new List<Position>();
        }

        public static List<Personnel> GetPersonnelListByNameOrCode(string searchText)
        {
            var personnelListByName = Personel_FindByName(searchText) ?? new List<Personnel>();
            var personnelByCode = Personel_FindByCode(searchText);
            var personnelByNationalCode = Personel_FindByNationalCode(searchText);

            AddIfNotExists(personnelListByName, personnelByCode);
            AddIfNotExists(personnelListByName, personnelByNationalCode);

            return personnelListByName;
        }

        public static Personnel Personel_FindByCode(string searchText)
        {
            var personnel = ExternalServices.GetAfra().Personel_FindByCode(searchText);
            var result = ServiceBusResult.Validate(personnel);
            return result != null ? GetPersonnel(result) : null;
        }

        public static List<Personnel> Personel_FindByName(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return new List<Personnel>();

            var personnelList = ExternalServices.GetAfra().Personel_FindByName(searchText);
            var result = ServiceBusResult.Validate(personnelList);
            return result?.Select(GetPersonnel).ToList() ?? new List<Personnel>();
        }

        public static List<Unit> GetUnitListByNameOrCode(string searchTerm, string unitType = null)
        {
            var findUnitListByName = Unit_FindByName(searchTerm) ?? new List<Unit>();
            var findUnitByCode = Unit_FindByCode(searchTerm);

            AddIfNotExists(findUnitListByName, findUnitByCode);

            return findUnitListByName.Where(x => unitType == null || x.Type == unitType).ToList();
        }

        public static List<Unit> Unit_GetByType(string unitType)
        {
            var unitList = ExternalServices.GetAfra().Unit_GetByType(unitType);
            var result = ServiceBusResult.Validate<List<OutUnit>>(unitList);
            return result?.Select(GetUnit).ToList() ?? new List<Unit>();
        }

        public static List<OutCity> City_FindByName(string searchText)
        {
            var pageInfo = new InPageInfo { PageNumber = 1, PageSize = Constant.AfraMaxLengthData };
            var city = ExternalServices.GetAfra().City_FindByName(pageInfo, searchText);
            var result = ServiceBusResult.Validate(city);
            return result?.Result.Result.ToList() ?? new List<OutCity>();
        }

        public static List<OutNewUnit> City_GetUnitsByName(string searchTerm, string cityCode)
        {
            var pageInfo = new InPageInfo { PageNumber = 1, PageSize = Constant.AfraMaxLengthData };
            var unit = ExternalServices.GetAfra().City_GetUnitsByName(pageInfo, cityCode, searchTerm);
            var result = ServiceBusResult.Validate(unit);

            return result?.Result.Result
                .Where(x => x.Type == AfraConstant.BranchManagementType)
                .ToList() ?? new List<OutNewUnit>();
        }

        public static Unit Unit_FindByCode(string searchText)
        {
            var unitList = ExternalServices.GetAfra().Unit_FindByCode(searchText);
            var result = ServiceBusResult.Validate(unitList);
            return result != null ? GetUnit(result) : null;
        }

        public static List<Unit> GetUnitByUnitTypeList(string searchText, List<string> unitTypeList)
        {
            var unitTypeSet = new HashSet<string>(unitTypeList ?? new List<string>());
            return GetUnitListByNameOrCode(searchText)
                .Where(unit => unitTypeSet.Contains(unit.Type))
                .Take(Constant.AfraMaxLengthData)
                .ToList();
        }

        public static bool IsUnitsInRegion(string unitCode, string regionId)
        {
            if (string.IsNullOrEmpty(unitCode) || string.IsNullOrEmpty(regionId))
                return false;

            return GetUnitListByNameOrCode(regionId)
                .Where(branch => branch.Children != null)
                .SelectMany(branch => branch.Children)
                .Any(unit => unit.Code == unitCode);
        }

        public static List<Unit> GetUnitsByBranchManagement(string searchText, string regionId)
        {
            if (string.IsNullOrEmpty(searchText) || string.IsNullOrEmpty(regionId))
                return new List<Unit>();

            return GetUnitListByNameOrCode(regionId)
                .Where(branch => branch.Children != null)
                .SelectMany(branch => branch.Children)
                .Where(unit => unit.Type.Equals(AfraConstant.BranchType) &&
                               (unit.Code == searchText ||
                                unit.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)))
                .Take(7)
                .ToList();
        }

        public static List<Unit> GetUnits(string searchTerm, List<string> filterUnitList)
        {
            var filterSet = new HashSet<string>(filterUnitList ?? new List<string>());
            return GetUnitListByNameOrCode(searchTerm)
                .Where(unit => filterSet.Contains(unit.Code))
                .ToList();
        }

        public static List<Unit> GetParentPath(string searchTerm)
        {
            var unitList = ExternalServices.GetAfra().Unit_GetParentPath(searchTerm);
            var result = ServiceBusResult.Validate<List<OutUnit>>(unitList);
            return result?.Select(GetUnit).ToList() ?? new List<Unit>();
        }

        public static ZimaAutoCompleteItem[] GetZimaAutoCompleteRecords<T>(
            List<T> items,
            Func<T, string> getLabel,
            Func<T, string> getValue)
        {
            var zimaAutoCompleteRecords = new ZimaAutoCompleteRecords();

            foreach (var item in items ?? new List<T>())
            {
                zimaAutoCompleteRecords.AddRecord(new ZimaAutoCompleteItem
                {
                    Label = getLabel(item),
                    Value = getValue(item)
                });
            }

            return zimaAutoCompleteRecords.GetRecords();
        }

        // Overloads for backward compatibility
        public static ZimaAutoCompleteItem[] GetZimaAutoCompleteRecords(List<Unit> unitList)
            => GetZimaAutoCompleteRecords(unitList, u => u.NameCode, u => u.Code);

        public static ZimaAutoCompleteItem[] GetZimaAutoCompleteRecords(List<OutNewUnit> unitList)
            => GetZimaAutoCompleteRecords(unitList, u => u.Name, u => u.Code);

        public static ZimaAutoCompleteItem[] GetZimaAutoCompleteRecords(List<OutCity> cityList)
            => GetZimaAutoCompleteRecords(cityList, c => c.Name, c => c.Code);

        #endregion Public Functions

        #region Private Functions

        private static Personnel Personel_FindByNationalCode(string searchText)
        {
            var personnel = ExternalServices.GetAfra().Personel_FindByNationalCode(searchText);
            var result = ServiceBusResult.Validate(personnel);
            return result != null ? GetPersonnel(result) : null;
        }

        private static List<Unit> Unit_FindByName(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return new List<Unit>();

            var unitList = ExternalServices.GetAfra().Unit_FindByName(searchText);
            var result = ServiceBusResult.Validate(unitList);
            return result?.Select(GetUnit).ToList() ?? new List<Unit>();
        }

        private static void AddIfNotExists(List<Personnel> list, Personnel item)
        {
            if (item != null && !list.Any(p => p.Code == item.Code))
            {
                list.Add(item);
            }
        }

        private static void AddIfNotExists(List<Unit> list, Unit item)
        {
            if (item != null && !list.Any(u => u.Code == item.Code))
            {
                list.Add(item);
            }
        }

        private static void AddIfNotExistsDistinct(List<Position> list, Position item)
        {
            if (item != null && !list.Any(p => p.Code == item.Code))
            {
                list.Add(item);
            }
        }

        private static Position GetPosition(OutPosition v)
        {
            return new Position
            {
                Code = v.Code,
                Name = v.Name
            };
        }

        private static Personnel GetPersonnel(Personel v)
        {
            return new Personnel
            {
                Id = v.Id,
                Code = v.Code,
                Name = v.Name,
                CurrentUnit = v.CurrentUnit != null ? new Unit
                {
                    Code = v.CurrentUnit.Code,
                    Name = v.CurrentUnit.Name
                } : null,
                CurrentPosition = v.CurrentPosition != null ? new Position
                {
                    Code = v.CurrentPosition.Code,
                    Name = v.CurrentPosition.Name
                } : null,
                NationalCode = v.NationalCode,
                MobileNumber = v.MobileNumber
            };
        }

        private static Unit GetUnit(OutUnit v)
        {
            return new Unit
            {
                Code = v.Code,
                Name = v.Name,
                Type = v.Type,
                Children = v.Children?.Select(GetUnit).ToArray()
            };
        }

        #endregion Private Functions
    }

}
