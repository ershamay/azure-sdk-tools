﻿# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

######################
#
# Validate that the given code block throws the given exception
#
#    param [ScriptBlock] $script: The code to test
#    param [string] $message    : The text of the exception that should be thrown
#######################
function Assert-Throws
{
   param([ScriptBlock] $script, [string] $message)
   try 
   {
      &$script
   }
   catch 
   {
       Write-Output ("Caught exception: '" + $_.Exception.Message + "'")
       if ($_.Exception.Message -eq $message)
	   {
	       return $true;
	   }
   }

   throw "Expected exception not received: '$message'";
}

###################
#
# Verify that the given scriptblock returns true
#
#    param [ScriptBlock] $script: The script to execute
#    param [string] $message    : The message to return if the given script does not return true
####################
function Assert-True
{
    param([ScriptBlock] $script, [string] $message)
	
	if (!$message)
	{
	    $message = "Assertion failed: " + $script
	}
	
    $result = &$script
	if (-not $result) 
	{
	    throw $message
	}
	
	return $true
}

###################
#
# Verify that the given scriptblock does not return null
#
#    param [object] $actual  : The actual object
#    param [string] $message : The message to return if the given script does not return true
####################
function Assert-NotNull
{
    param([object] $actual, [string] $message)
	
	if (!$message)
	{
	    $message = "Assertion failed because the object in null: " + $actual
	}
	
	if ($actual -eq $null) 
	{
	    throw $message
	}
	
	return $true
}

######################
#
# Assert that the given file exists
#
#    param [string] $path   : The path to the file to test
#    param [string] $message: The text of the exception to throw if the file doesn't exist
######################
function Assert-Exists
{
    param([string] $path, [string] $message) 
	return Assert-True {Test-Path $path} $message
}

###################
#
# Verify that two given objects are equal
#
#    param [object] $expected : The expected object
#    param [object] $actual   : The actual object
#    param [string] $message  : The message to return if the given script does not return true
####################
function Assert-AreEqual
{
    param([object] $expected, [object] $actual, [string] $message)
	
	if (!$message)
	{
	    $message = "Assertion failed because expected '$expected' does not match actual '$actual'"
	}
	
	if ($expected -ne $actual) 
	{
	    throw $message
	}
	
	return $true
}