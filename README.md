# WouldBePDM
"Would-Be PDM" (I whish a was a PDM) is a group of CATIA macros for manage CATIA projects via SVN using tortoise.

I assume that you know how to add a macro in CATIA.

Quick instructions

These the "macro" to add (to launch) in CATIA:
-WouldBePDM.catvba
	-Begin
the main macro which contains the forms and the commands
-"SVN Commit Active Document.catvbs"
To commit (upload) the current CATIA document
-"SVN Update Active Document_4_0.catvbs"
To update (download) the updated version of the current CATIA document
-"SVN Lock Active Document_4_0.catvbs"
To Lock the current CATIA document
-"SVN UnLock Active Document_3_0.catvbs"
To unLock the current CATIA document
-"SVN Status Active Document.catvbs"
To View the status of the current CATIA document
-"Close_All.catvbs"
To close all the documents
-"open_dir.catvbs"
To open the dir of the current document

The tree should be the following:
CAD_001\
-CAD_001\PRJ_List.txt
The file where the projects are listed
-CAD_001\project1.txt, project2.txt, anyname.txt
The file where all the documents of a project are listed
CAD_001\File_CAD\
the directory where the CAD files are

I assume that CAD_001 is a svn directory (it means that you have a svn repository of the CAD_001 dir.



