
/****** Object:  ForeignKey [FK_Funds_Projects]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Funds]  WITH NOCHECK ADD  CONSTRAINT [FK_Funds_Projects] FOREIGN KEY([ppm_recordid])
REFERENCES [Publicworks].[Projects] ([PPM_Recordid])
GO
ALTER TABLE [Publicworks].[Funds] CHECK CONSTRAINT [FK_Funds_Projects]
GO
/****** Object:  ForeignKey [FK_Projects_ArchitectEngineers]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Projects]  WITH NOCHECK ADD  CONSTRAINT [FK_Projects_ArchitectEngineers] FOREIGN KEY([PPA_Recordid])
REFERENCES [Publicworks].[ArchitectEngineers] ([recordid])
GO
ALTER TABLE [Publicworks].[Projects] CHECK CONSTRAINT [FK_Projects_ArchitectEngineers]
GO
/****** Object:  ForeignKey [FK_Projects_Consultants]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Projects]  WITH NOCHECK ADD  CONSTRAINT [FK_Projects_Consultants] FOREIGN KEY([PPN_Recordid])
REFERENCES [Publicworks].[Consultants] ([ppn_recordid])
GO
ALTER TABLE [Publicworks].[Projects] CHECK CONSTRAINT [FK_Projects_Consultants]
GO
/****** Object:  ForeignKey [FK_Projects_Contractors]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Projects]  WITH NOCHECK ADD  CONSTRAINT [FK_Projects_Contractors] FOREIGN KEY([PPC_Recordid])
REFERENCES [Publicworks].[Contractors] ([ppc_recordid])
GO
ALTER TABLE [Publicworks].[Projects] CHECK CONSTRAINT [FK_Projects_Contractors]
GO
/****** Object:  ForeignKey [FK_Projects_ProjectManagers]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Projects]  WITH NOCHECK ADD  CONSTRAINT [FK_Projects_ProjectManagers] FOREIGN KEY([PPR_Recordid])
REFERENCES [Publicworks].[ProjectManagers] ([ppr_recordid])
GO
ALTER TABLE [Publicworks].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectManagers]
GO
/****** Object:  ForeignKey [FK_Projects_ProjectTypes]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Projects]  WITH NOCHECK ADD  CONSTRAINT [FK_Projects_ProjectTypes] FOREIGN KEY([PPT_Recordid])
REFERENCES [Publicworks].[ProjectTypes] ([ppt_recordid])
GO
ALTER TABLE [Publicworks].[Projects] CHECK CONSTRAINT [FK_Projects_ProjectTypes]
GO
/****** Object:  ForeignKey [FK_Projects_Secretary]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Projects]  WITH NOCHECK ADD  CONSTRAINT [FK_Projects_Secretary] FOREIGN KEY([PPS_Recordid])
REFERENCES [Publicworks].[Secretary] ([pps_recordid])
GO
ALTER TABLE [Publicworks].[Projects] CHECK CONSTRAINT [FK_Projects_Secretary]
GO
/****** Object:  ForeignKey [FK_Projects_Users]    Script Date: 11/23/2011 12:58:28 ******/
ALTER TABLE [Publicworks].[Projects]  WITH NOCHECK ADD  CONSTRAINT [FK_Projects_Users] FOREIGN KEY([PPU_Recordid])
REFERENCES [Publicworks].[Users] ([ppu_recordid])
GO
ALTER TABLE [Publicworks].[Projects] CHECK CONSTRAINT [FK_Projects_Users]
GO

update Publicworks.Projects set PPC_Recordid = 1450 where PPC_Recordid IS Null
update Publicworks.Projects set PPN_Recordid = 407 where PPN_Recordid IS Null
update Publicworks.Projects set PPC_Recordid = 1450 where PPC_Recordid = 1532