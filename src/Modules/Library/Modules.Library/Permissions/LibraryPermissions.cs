namespace FSH.Modules.Library.Permissions;

/// <summary>
/// Permission constants for the Library module.
/// </summary>
public static class LibraryPermissions
{
    public static class Employees
    {
        public const string View = "library.employees.view";
        public const string Create = "library.employees.create";
        public const string Update = "library.employees.update";
        public const string Delete = "library.employees.delete";
    }

    public static class Offices
    {
        public const string View = "library.offices.view";
        public const string Create = "library.offices.create";
        public const string Update = "library.offices.update";
        public const string Delete = "library.offices.delete";
    }

    public static class Suppliers
    {
        public const string View = "library.suppliers.view";
        public const string Create = "library.suppliers.create";
        public const string Update = "library.suppliers.update";
        public const string Delete = "library.suppliers.delete";
    }

    public static class Categories
    {
        public const string View = "library.categories.view";
        public const string Create = "library.categories.create";
        public const string Update = "library.categories.update";
        public const string Delete = "library.categories.delete";
    }
}
