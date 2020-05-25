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


        public AutoAssembly DefineAssembly(string _AssemblyName) {
            assemblyName = new AssemblyName(_AssemblyName);
            assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndCollect);
            return this;
        }

       

        public AutoAssembly DefineModule(string ModuleName) {
            moduleBuilder = assemblyBuilder.DefineDynamicModule(ModuleName);
            return this;
        }

        public AutoAssembly DefineType(string MyDynamicType) {
            typeBuilder = moduleBuilder.DefineType(
              MyDynamicType,
               TypeAttributes.Public);
            return this;
        }
        public AutoAssembly SetParent(Type type)
        {
            typeBuilder.SetParent(type);
            return this;
        }

        public AutoAssembly Set


    }
}
