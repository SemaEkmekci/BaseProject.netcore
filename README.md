# ChatAppServer
# Renaming a .NET Project

Follow these steps to rename your .NET project:

## 1. Backup Your Project
First, make sure to create a backup of your project. Simply copy your entire project folder to a different directory for safety.

## 2. Rename the Project in Solution Explorer
In **Solution Explorer**, right-click on the project and select **Rename**.  
Enter the new name for your project.

## 3. Update Project Properties
Right-click on the project in **Solution Explorer** and select **Properties**.  
Go to the **Application** tab and update the following:
- **Assembly name**: Change this to the new project name.
- **Default namespace**: Update this to reflect the new project name.

## 4. Rename Namespaces
Open any `.cs` file within your project.  
Rename the namespaces to match the new project name.

## 5. Update Assembly Information
Change the **AssemblyTitle** and **AssemblyProduct** in the `Properties/AssemblyInfo.cs` file to reflect the new project name.

## 6. Delete `bin` and `obj` Directories
Manually delete the `bin` and `obj` directories from your project. These will be regenerated when the project is rebuilt.

## 7. Rename the Physical Project Folder
Rename the physical folder that contains your project files to the new project name.

## 8. Update the Solution File
Open the `.sln` file in a text editor (e.g., Notepad).  
Change the path to the project to reflect the new project folder name.

## 9. Clean and Rebuild the Project
In Visual Studio, clean and rebuild the solution to ensure all references are updated and the project works correctly with the new name.
