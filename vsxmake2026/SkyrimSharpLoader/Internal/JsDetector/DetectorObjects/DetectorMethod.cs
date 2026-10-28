using SkyrimSharpLoader.Attributes;
using SkyrimSharpLoader.Extensions;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SkyrimSharpLoader.Internal.JsDetector.DetectorObjects
{
    public class DetectorMethod(MethodInfo method) : DetectorObject
    {
        public MethodInfo Method = method;

        public override string Serialize()
        {
            var parameters = Method.GetParameters();

            var eventInfo = Method.GetCustomAttribute<EventInfoAttribute>();

            if (Method.GetCustomAttribute<ExtensionAttribute>() != null)
                parameters = [..parameters.Skip(1)];

            var paramTexts = string.Join(", ", parameters.Select(p =>
            {
                var @default = p.IsOptional ? " = " + Default2String(p.DefaultValue) : "";

                var pName = p.Name.IsNullOrWhiteSpaceNotEmpty() ? p.ParameterType.Name.LowerFirst() : p.Name;

                return $"{SpecialNameCheck(pName)}: {Type2ClassName(p.ParameterType, eventInfo?.ParameterNames, true)}{@default}";
            }));

            if (Method.GetCustomAttribute<ExtensionAttribute>() != null)
            {
                var genericTexts = "";

                if (Method.IsGenericMethod)
                {
                    var selfParam = Method.GetParameters().First().ParameterType;

                    var remaining = string.Join(", ", Method.GetGenericArguments()
                        .Where(t => t != selfParam)
                        .Select(t => t.Name));

                    if (remaining != "")
                        genericTexts = $"<{remaining}>";
                }

                return $"\"{Method.Name}\"{genericTexts}({paramTexts}): {Type2ClassName(Method.ReturnType, asParameter: true)}";
            }

            if (Method.IsGenericMethod)
            {
                var genericParams = Method.GetGenericArguments();

                var genericTexts = string.Join(", ", genericParams.Select(t => t.Name));

                return $"{(Method.IsStatic ? "static " : "")}\"{Method.Name}\"<{genericTexts}>({paramTexts}): {Type2ClassName(Method.ReturnType, asParameter: true)}";
            }

            return $"{(Method.IsStatic ? "static " : "")}\"{Method.Name}\"({paramTexts}): {Type2ClassName(Method.ReturnType, asParameter: true)}";
        }

        public string Default2String(object @default)
        {
            return @default switch
            {
                string => $"\"{@default}\"",
                char => $"'{@default}'",
                null => "null",
                false => "false",
                true => "true",
                _ => @default.ToString(),
            };
        }
    }
}
