using System;
using Library;

[Version(2.45)]
class ApplyAttribute
{
    static void Main()
    {
        //get all attributes with Refleciton
        Type ver = typeof(ApplyAttribute);

        object[] allAttributes = ver.GetCustomAttributes(false);

        foreach (VersionAttribute attribute in allAttributes)
        {
            Console.WriteLine(attribute.Version);
        }
    }
}
