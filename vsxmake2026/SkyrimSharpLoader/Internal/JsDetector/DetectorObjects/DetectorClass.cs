using SkyrimSharpLoader.Extensions;
using SkyrimSharpLoader.Utils;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace SkyrimSharpLoader.Internal.JsDetector.DetectorObjects
{
    public class DetectorClass : DetectorObject
    {
        public DetectorModule Module;

        public DetectorClass(Type type, DetectorModule module)
        {
            Type = type;

            Module = module;

            foreach (var i in Type.GetMembers())
                AddMember(i);
        }

        public Type Type;

        public List<DetectorMember> Members = [];

        public override string Serialize()
        {
            var ret = new StringBuilder();

            var typeDef = Type.IsInterface ? "interface" : "class";

            if (Type.IsAbstract)
                typeDef = "abstract " + typeDef;

            ret.AppendLine($"export {typeDef} {Type2ClassName(Type)}" + (Type.BaseType == null ? "" : $" extends {Type2ClassName(Type.BaseType)}") + " {");

            foreach (var i in Members)
            {
                var ser = i.Serialize();

                if(ser != "")
                    ret.AppendLine(ser);
            }

            if (typeof(IEnumerable).IsAssignableFrom(Type))
            {
                var t = Type.GetInterfaces().Append(Type)
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                if (t != null)
                    ret.AppendLine($"[Symbol.iterator](): Iterator<{Type2ClassName(t.GetGenericArguments()[0])}>");
            }

            ret.AppendLine("}");

            return ret.ToString();
        }

        public void AddMember(MemberInfo info)
        {
            if (info is PropertyInfo property && property.PropertyType.IsByRef)
                return;

            if (info is FieldInfo field && field.FieldType.IsByRef)
                return;

            if (info is ConstructorInfo && Type.IsStatic())
                return;

            if (info is MethodInfo method)
            {
                if (method.IsIllegal())
                    return;

                if (method.GetCustomAttribute<ExtensionAttribute>() != null)
                {
                    foreach (var targetType in RegistrationKeys(method.GetParameters().First().ParameterType))
                    {
                        if (JsDetector.ExtensionMethods.TryGetValue(targetType, out var extMethods))
                            extMethods.Add(method);
                        else
                            JsDetector.ExtensionMethods.TryAdd(targetType, [method]);
                    }

                    return;
                }
            }

            if (Members.Exists(t => t.MemberInfo.Name == info.Name))
            {
                if (info is MethodInfo methodInfo)
                {
                    var target = Members.First(t => t.MemberInfo.Name == info.Name).MemberInfo as MethodInfo;

                    var infoParams = RegistryUtils.Parameters2Types(methodInfo.GetParameters());

                    var targetParams = RegistryUtils.Parameters2Types(target.GetParameters());

                    if (infoParams.SequenceEqual(targetParams) && methodInfo.ReturnType == target.ReturnType)
                        return;
                }
                else if (info is ConstructorInfo constructorInfo)
                {
                    var target = Members.First(t => t.MemberInfo.Name == info.Name).MemberInfo as ConstructorInfo;

                    var infoParams = RegistryUtils.Parameters2Types(constructorInfo.GetParameters());

                    var targetParams = RegistryUtils.Parameters2Types(target.GetParameters());

                    if (infoParams.SequenceEqual(targetParams))
                        return;
                }
                else
                {
                    var target = Members.First(t => t.MemberInfo.Name == info.Name);

                    if (target.MemberInfo.DeclaringType != Type)
                        target.MemberInfo = info;

                    return;
                }
            }

            Members.TryAdd(new(info));
        }

        private static IEnumerable<Type> RegistrationKeys(Type targetType)
        {
            if (!targetType.IsGenericParameter)
            {
                yield return targetType;

                yield break;
            }

            foreach (var constraint in targetType.GetGenericParameterConstraints())
            {
                if (!constraint.IsInterface || constraint.IsGenericType)
                    continue;

                yield return constraint;
            }
        }

        private static IEnumerable<Type> LookupKeys(Type type)
        {
            yield return type;

            foreach (var i in type.GetInterfaces())
                yield return i;
        }

        public void AddExtensionMethods()
        {
            foreach (var key in LookupKeys(Type))
            {
                if (!JsDetector.ExtensionMethods.TryGetValue(key, out var extMethods))
                    continue;

                foreach (var method in extMethods)
                {
                    if (Members.Exists(m => m.MemberInfo.Name == method.Name))
                        continue;

                    Members.TryAdd(new(method));

                    Module.AddImport(method.ReturnType);

                    foreach (var p in method.GetParameters())
                        Module.AddImport(p.ParameterType);

                    if (method.IsGenericMethod)
                        Module.AddImport(typeof(Type));
                }
            }
        }

        public override bool Equals(object obj) => obj is DetectorClass clazz && clazz.Type == Type;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
