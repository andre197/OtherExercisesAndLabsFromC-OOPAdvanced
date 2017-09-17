using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    private StringBuilder sb;
    private Type classInfo;

    public string StealFieldInfo(string className, params string[] requestedFields)
    {
        this.classInfo = Type.GetType(className);
        FieldInfo[] fieldsInfo = classInfo.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

        Object classInstance = Activator.CreateInstance(classInfo, new object[] { });

        this.sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var item in fieldsInfo.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        this.classInfo = Type.GetType(className);

        FieldInfo[] nonPrivateFields = classInfo.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] publicMethods = classInfo.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] nonPublicMethods = classInfo.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        this.sb = new StringBuilder();

        foreach (var item in nonPrivateFields)
        {
            sb.AppendLine($"{item.Name} must be private!");
        }
        foreach (MethodInfo method in nonPublicMethods.Where(p => p.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach (MethodInfo prop in publicMethods.Where(p => p.Name.StartsWith("set")))
        {
            sb.AppendLine($"{prop.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        this.classInfo = Type.GetType(className);

        MethodInfo[] methods = classInfo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        this.sb = new StringBuilder();
        this.sb.AppendLine($"All Private Methods of Class: {className}");
        this.sb.AppendLine($"Base Class: {this.classInfo.BaseType.Name}");

        foreach (var item in methods)
        {
            this.sb.AppendLine($"{item.Name}");
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        this.classInfo = Type.GetType(className);

        MethodInfo[] getMethods = classInfo.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        sb = new StringBuilder();
        foreach (var item in getMethods.Where(g => g.Name.StartsWith("get")))
        {
            sb.AppendLine($"{item.Name} will return {item.ReturnType.FullName}");
        }

        foreach (var item in getMethods.Where(s => s.Name.StartsWith("set")))
        {
            sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}

