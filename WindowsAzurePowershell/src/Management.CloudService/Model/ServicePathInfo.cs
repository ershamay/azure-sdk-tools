﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Management.CloudService.Model
{
    using System.IO;
    using Microsoft.WindowsAzure.Management.Utilities;
    using Properties;

    public class ServicePathInfo
    {
        public string Definition { get; private set; }
        public string CloudConfiguration { get; private set; }
        public string LocalConfiguration { get; private set; }
        public string Settings { get; private set; }
        public string CloudPackage { get; private set; }
        public string LocalPackage { get; private set; }
        public string RootPath { get; private set; }

        public ServicePathInfo(string rootPath)
        {
            Validate.ValidateStringIsNullOrEmpty(rootPath, "service definition (*.csdef) file");
            Validate.ValidatePathName(rootPath, Resources.InvalidRootNameMessage);

            RootPath = rootPath;
            Definition = Path.Combine(rootPath, Resources.ServiceDefinitionFileName);
            CloudConfiguration = Path.Combine(rootPath, Resources.CloudServiceConfigurationFileName);
            LocalConfiguration = Path.Combine(rootPath, Resources.LocalServiceConfigurationFileName);
            Settings = Path.Combine(rootPath, Resources.SettingsFileName);
            CloudPackage = Path.Combine(rootPath, Resources.CloudPackageFileName);
            LocalPackage = Path.Combine(rootPath, Resources.LocalPackageFileName);
        }
    }
}