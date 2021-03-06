// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.Tools.Vhd.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class VhdEntityDescriptor<T>
    {
        public VhdEntityDescriptor()
        {
            this.PropertyDescriptors = GetPropertyDescriptors();
        }

        public IList<VhdPropertyDescriptor> PropertyDescriptors { get; private set; }

        static IList<VhdPropertyDescriptor> GetPropertyDescriptors()
        {
            return (from p in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    let vhdPropertyAttributes = p.GetCustomAttributes(typeof(VhdPropertyAttribute), false)
                    let exists = vhdPropertyAttributes.Length > 0
                    let getter = p.GetGetMethod(true)
                    let setter = p.GetSetMethod(true)
                    where exists
                    select new VhdPropertyDescriptor
                               {
                                   Attribute = (VhdPropertyAttribute)(vhdPropertyAttributes[0]),
                                   Getter = getter,
                                   Setter = setter
                               }).ToList();
        }
    }
}