using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace KY.RuntimeEntity
{
    public class AutoAssembly
    {
        public AssemblyName assemblyName { get; set; }
        public AssemblyBuilder  assemblyBuilder { get; set; }

        public ModuleBuilder moduleBuilder { get; set; }
        public TypeBuilder typeBuilder { get; set; }

        public void DefineEntity() {
           
            ModuleBuilder mb = ab.DefineDynamicModule("aName.Name");
            TypeBuilder tb = mb.DefineType(
           "MyDynamicType",
            TypeAttributes.Public);
        }

        /// <summary>
        /// ★1
        /// </summary>
        /// <param name="_AssemblyName"></param>
        /// <returns></returns>
        public AutoAssembly DefineAssembly(string _AssemblyName) {
            assemblyName = new AssemblyName(_AssemblyName);
            assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);
            return this;
        }


        /// <summary>
        /// ★2
        /// </summary>
        /// <param name="_AssemblyName"></param>
        /// <returns></returns>
        public AutoAssembly DefineModule(string ModuleName) {
            moduleBuilder = assemblyBuilder.DefineDynamicModule(ModuleName);
            return this;
        }
        /// <summary>
        /// ★3
        /// </summary>
        /// <param name="_AssemblyName"></param>
        /// <returns></returns>
        public AutoAssembly DefineType(string MyDynamicType) {
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

        public AutoAssembly Set


    }
}
