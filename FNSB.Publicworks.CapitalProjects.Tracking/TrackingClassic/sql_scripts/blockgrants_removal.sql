/* Delete the child Funding records linked to the active bloack grant projects */
DELETE FROM Publicworks.Funds WHERE EXISTS 
(Select * from Publicworks.Projects Where (Publicworks.Funds.ppm_recordid = Publicworks.Projects.PPM_Recordid
 and (Publicworks.Projects.PPM_Project_Active = 1 and Publicworks.Projects.PPR_Recordid = 535)))
 
/*delete the projects that are block grants */
DELETE FROM Publicworks.Projects where PPR_Recordid = 535 and PPM_Project_Active = 1