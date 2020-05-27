using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KY.NetForm
{
    public   class Service
    {
        public AutoAssembly assembly { get; set; }

        public Service() {
            assembly = new AutoAssembly();
        }
        public  Service CreateAndSave(string assemblyName,string ModuleName,string DefineType,IEnumerable<MyProerty> myProerties,string DllName) {
            
            assembly.DefineAssembly(assemblyName).DefineModule(ModuleName).DefineType(DefineType).SetProerties(myProerties).Save(DllName);
            return this;
        }

        public object InitData(Dictionary<string,object> keyValues) {
            var data = assembly.resultType;
            object instanceData = Activator.CreateInstance(data);
            foreach (var item in keyValues)
            {
                instanceData.GetType().GetProperty(item.Key).SetValue(instanceData, item.Value);
            }
            return instanceData;
        }

    }
}
