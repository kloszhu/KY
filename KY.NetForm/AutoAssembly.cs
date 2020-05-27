using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KY.NetForm
{
    public class AutoAssembly
    {
        public AssemblyName assemblyName { get; set; }

        public AssemblyBuilder assemblyBuilder { get; set; }

        public ModuleBuilder moduleBuilder { get; set; }

        public TypeBuilder typeBuilder { get; set; }

        public string prefixField { get; set; } = "member_";

        public Type resultType { get; set; }

        public void DefineEntity()
        {

            // ModuleBuilder mb = ab.DefineDynamicModule("aName.Name");
            // TypeBuilder tb = mb.DefineType(
            //"MyDynamicType",
            // TypeAttributes.Public);
        }

        /// <summary>
        /// ★1
        /// </summary>
        /// <param name="_AssemblyName"></param>
        /// <returns></returns>
        public AutoAssembly DefineAssembly(string _AssemblyName)
        {
            assemblyName = new AssemblyName(_AssemblyName);
            assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            return this;
        }


        /// <summary>
        /// ★2
        /// </summary>
        /// <param name="_AssemblyName"></param>
        /// <returns></returns>
        public AutoAssembly DefineModule(string ModuleName)
        {
            moduleBuilder = assemblyBuilder.DefineDynamicModule(ModuleName);
            return this;
        }
        /// <summary>
        /// ★3
        /// </summary>
        /// <param name="_AssemblyName"></param>
        /// <returns></returns>
        public AutoAssembly DefineType(string MyDynamicType)
        {
            typeBuilder = moduleBuilder.DefineType(
              MyDynamicType,
               TypeAttributes.Public);
            return this;
        }
        /// <summary>
        /// ★4
        /// </summary>
        /// <param name="_AssemblyName"></param>
        /// <returns></returns>
        public AutoAssembly SetParent(Type type)
        {
            typeBuilder.SetParent(type);
            return this;
        }

        public AutoAssembly SetProperty(string property_Name, Type type)
        {

            #region 添加Field字段
            FieldBuilder fbNumber = typeBuilder.DefineField(
            prefixField + property_Name,
            type,
            FieldAttributes.Private);

            #endregion

            #region 添加property属性字段
            PropertyBuilder pbNumber = typeBuilder.DefineProperty(property_Name, PropertyAttributes.HasDefault, type,
  null);

            // The property "set" and property "get" methods require a special
            // set of attributes.
            MethodAttributes getSetAttr = MethodAttributes.Public |
                MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            // Define the "get" accessor method for Number. The method returns
            // an integer and has no arguments. (Note that null could be
            // used instead of Types.EmptyTypes)
            MethodBuilder mbNumberGetAccessor = typeBuilder.DefineMethod(
                "get_" + property_Name,
                getSetAttr,
                typeof(int),
                Type.EmptyTypes);

            ILGenerator numberGetIL = mbNumberGetAccessor.GetILGenerator();
            // For an instance property, argument zero is the instance. Load the
            // instance, then load the private field and return, leaving the
            // field value on the stack.
            numberGetIL.Emit(OpCodes.Ldarg_0);
            numberGetIL.Emit(OpCodes.Ldfld, fbNumber);
            numberGetIL.Emit(OpCodes.Ret);

            // Define the "set" accessor method for Number, which has no return
            // type and takes one argument of type int (Int32).
            MethodBuilder mbNumberSetAccessor = typeBuilder.DefineMethod(
                "set_" + property_Name,
                getSetAttr,
                null,
                new Type[] { typeof(int) });

            ILGenerator numberSetIL = mbNumberSetAccessor.GetILGenerator();
            // Load the instance and then the numeric argument, then store the
            // argument in the field.
            numberSetIL.Emit(OpCodes.Ldarg_0);
            numberSetIL.Emit(OpCodes.Ldarg_1);
            numberSetIL.Emit(OpCodes.Stfld, fbNumber);
            numberSetIL.Emit(OpCodes.Ret);

            // Last, map the "get" and "set" accessor methods to the
            // PropertyBuilder. The property is now complete.
            pbNumber.SetGetMethod(mbNumberGetAccessor);
            pbNumber.SetSetMethod(mbNumberSetAccessor);
            return this;
        }

        public AutoAssembly SetProerties(IEnumerable<MyProerty> proerties)
        {
            foreach (var item in proerties)
            {
                SetProperty(item.ProertyName, item.PropertyType);
            }
            return this;
        }

        public AutoAssembly SetConstract(Type[] parameterTypes = null)
        {
            if (parameterTypes == null)
            {
                parameterTypes = Type.EmptyTypes;
            }
            ConstructorBuilder ctor1 = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard, parameterTypes);
            #endregion

            return this;
        }

        public AutoAssembly Save(string DllName)
        {
            resultType = typeBuilder.CreateType();
            assemblyBuilder.Save(DllName + ".dll");

            return this;
        }

        public AutoAssembly CreatedEntity(Action action)
        {
            action.Invoke();
            return this;
        }



    }

    public class MyProerty
    {
        public string ProertyName { get; set; }
        public Type PropertyType { get; set; }
    }
}
