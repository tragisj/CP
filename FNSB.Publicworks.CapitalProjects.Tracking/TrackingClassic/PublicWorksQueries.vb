
Option Explicit On
Imports System.Configuration
Imports System.Data
Imports System.Data.Sql
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Generic

''' <summary>
''' Project Track Query queries CSPRojects Project_User_Definition and load into an ArrayList
''' </summary>
''' <remarks></remarks>
Public Class PublicWorksQueries

    Implements IDisposable
    Private Const PWC As String = "PWD"   'SQL Connection string from app.config 

    Public Function ProjectsDataTable(ByVal Type As PublicWorks.Type, ByVal SQL As String) As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As SqlConnection
        Dim ProjectCom As SqlCommand
        Dim ProjectDA As SqlDataAdapter

        ProjectCon = New SqlConnection
        ProjectCom = New SqlCommand
        ProjectDA = New SqlDataAdapter
        ProjectsDataTable = New DataTable

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCom.CommandText = SQL
            ProjectCom.Connection = ProjectCon
            ProjectCom.CommandType = CommandType.StoredProcedure
            ProjectDA.SelectCommand = ProjectCom

            'Dim mySQLCommandBuilder As SqlCommandBuilder = New SqlCommandBuilder(ProjectsDA)

            ProjectDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            ProjectDA.FillSchema(ProjectsDataTable, SchemaType.Source)
            ProjectDA.Fill(ProjectsDataTable)

            'Added this code to force Primary Key to associate on the datatable. 
            'The key is set on the DB but in some instances the key contraint isn't being passed at dt creation
            Dim dpk(0) As DataColumn
            dpk(0) = ProjectsDataTable.Columns(0)
            ProjectsDataTable.PrimaryKey = dpk

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (ProjectCom Is Nothing) Then
                    ProjectCom.Dispose()
                End If
                If Not (ProjectDA Is Nothing) Then
                    ProjectDA.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function ProjectsDelete(ByVal ProjectsDeleteRows() As DataRow)

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As New ConnectionStringSettings
        Dim ProjectsDA As New SqlDataAdapter()
        Dim deleteCmd As New SqlCommand()

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            deleteCmd.Connection = ProjectCon
            deleteCmd.CommandText = "Publicworks.usp_ppm_delete_mainbyrecordid"
            deleteCmd.CommandType = CommandType.StoredProcedure
            deleteCmd.Parameters.Add("@PPM_Recordid", SqlDbType.Int, 4, "PPM_Recordid")

            ProjectsDA.DeleteCommand = deleteCmd
            ProjectsDA.Update(ProjectsDeleteRows)

            Return 0

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (deleteCmd Is Nothing) Then
                    deleteCmd.Dispose()
                End If
                If Not (ProjectsDA Is Nothing) Then
                    ProjectsDA.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function ProjectsUpdate(ByVal ProjectsDataTable As DataTable) As Integer

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As New ConnectionStringSettings
        Dim ProjectsDA As New SqlDataAdapter()
        Dim insertCmd As New SqlCommand()
        Dim updateCmd As New SqlCommand()
        Dim deleteCmd As New SqlCommand()

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            insertCmd.Connection = ProjectCon
            insertCmd.CommandText = "Publicworks.usp_ppm_insert_main"
            insertCmd.CommandType = CommandType.StoredProcedure
            insertCmd.Parameters.Add("@PPM_Project_Name", SqlDbType.NVarChar, 255, "PPM_Project_Name")
            insertCmd.Parameters.Add("@PPM_Project_Number", SqlDbType.NVarChar, 255, "PPM_Project_Number")
            insertCmd.Parameters.Add("@PPM_Active_Date", SqlDbType.SmallDateTime, 4, "PPM_Active_Date")
            insertCmd.Parameters.Add("@PPM_Inactive_Date", SqlDbType.SmallDateTime, 4, "PPM_Inactive_Date")
            insertCmd.Parameters.Add("@PPM_Project_Active", SqlDbType.Bit, 1, "PPM_Project_Active")
            insertCmd.Parameters.Add("@PPM_Status_Desc", SqlDbType.NVarChar, 4000, "PPM_Status_Desc")
            insertCmd.Parameters.Add("@PPM_Per_Des_Complete", SqlDbType.Int, 4, "PPM_Per_Des_Complete")
            insertCmd.Parameters.Add("@PPM_Proj_Scope", SqlDbType.NVarChar, 4000, "PPM_Proj_Scope")
            insertCmd.Parameters.Add("@PPM_MSA_Update", SqlDbType.Bit, 1, "PPM_MSA_Update")
            insertCmd.Parameters.Add("@PPM_Consultant_Fee", SqlDbType.Money, 8, "PPM_Consultant_Fee")
            insertCmd.Parameters.Add("@PPM_Contract_Amount", SqlDbType.Money, 8, "PPM_Contract_Amount")
            insertCmd.Parameters.Add("@PPM_Contract_Amendments", SqlDbType.Money, 8, "PPM_Contract_Amendments")
            insertCmd.Parameters.Add("@PPM_CO", SqlDbType.Money, 8, "PPM_CO")
            insertCmd.Parameters.Add("@PPM_Per_Const_Complete", SqlDbType.Int, 4, "PPM_Per_Const_Complete")
            insertCmd.Parameters.Add("@PPM_IFB_RFQ", SqlDbType.NVarChar, 255, "PPM_IFB_RFQ")
            insertCmd.Parameters.Add("@PPM_User_Letter", SqlDbType.Bit, 1, "PPM_User_Letter")
            insertCmd.Parameters.Add("@PPM_RFP_Number", SqlDbType.NVarChar, 50, "PPM_RFP_Number")
            insertCmd.Parameters.Add("@NDI_RFP", SqlDbType.SmallDateTime, 4, "NDI_RFP")
            insertCmd.Parameters.Add("@NDI_Scope", SqlDbType.SmallDateTime, 4, "NDI_Scope")
            insertCmd.Parameters.Add("@NDI_Advertise_for_Bid", SqlDbType.SmallDateTime, 4, "NDI_Advertise_for_Bid")
            insertCmd.Parameters.Add("@NDI_Original_Bid_Date", SqlDbType.SmallDateTime, 4, "NDI_Original_Bid_Date")
            insertCmd.Parameters.Add("@NDI_Bid_Opening", SqlDbType.SmallDateTime, 4, "NDI_Bid_Opening")
            insertCmd.Parameters.Add("@NDI_Design_Complete", SqlDbType.SmallDateTime, 4, "NDI_Design_Complete")
            insertCmd.Parameters.Add("@NDI_Gen_Serv_Review", SqlDbType.SmallDateTime, 4, "NDI_Gen_Serv_Review")
            insertCmd.Parameters.Add("@NDI_Consultant_Award", SqlDbType.SmallDateTime, 4, "NDI_Consultant_Award")
            insertCmd.Parameters.Add("@NDI_Construction_Bid_Award", SqlDbType.SmallDateTime, 4, "NDI_Construction_Bid_Award")
            insertCmd.Parameters.Add("@NDI_Agenda_Setting", SqlDbType.SmallDateTime, 4, "NDI_Agenda_Setting")
            insertCmd.Parameters.Add("@NDI_Assembly_Approval", SqlDbType.SmallDateTime, 4, "NDI_Assembly_Approval")
            insertCmd.Parameters.Add("@NDI_NTP", SqlDbType.SmallDateTime, 4, "NDI_NTP")
            insertCmd.Parameters.Add("@NDI_Substantial_Completion", SqlDbType.SmallDateTime, 4, "NDI_Substantial_Completion")
            insertCmd.Parameters.Add("@NDI_Final", SqlDbType.SmallDateTime, 4, "NDI_Final")
            insertCmd.Parameters.Add("@NDI_Warranty_Period_Ends", SqlDbType.SmallDateTime, 4, "NDI_Warranty_Period_Ends")
            insertCmd.Parameters.Add("@NDI_Closed", SqlDbType.SmallDateTime, 4, "NDI_Closed")
            insertCmd.Parameters.Add("@PPS_Recordid", SqlDbType.Int, 4, "PPS_Recordid")
            insertCmd.Parameters.Add("@PPU_Recordid", SqlDbType.Int, 4, "PPU_Recordid")
            insertCmd.Parameters.Add("@PPT_Recordid", SqlDbType.Int, 4, "PPT_Recordid")
            insertCmd.Parameters.Add("@PPR_Recordid", SqlDbType.Int, 4, "PPR_Recordid")
            insertCmd.Parameters.Add("@PPC_Recordid", SqlDbType.Int, 4, "PPC_Recordid")
            insertCmd.Parameters.Add("@PPA_Recordid", SqlDbType.Int, 4, "PPA_Recordid")
            insertCmd.Parameters.Add("@PPN_Recordid", SqlDbType.Int, 4, "PPN_Recordid")
            insertCmd.Parameters.Add("@NOU_Recordid", SqlDbType.Int, 4, "NOU_Recordid")
            insertCmd.Parameters.Add("@FFM_Recordid", SqlDbType.Int, 4, "FFM_Recordid")
            insertCmd.Parameters.Add("@PPM_Project_Complete", SqlDbType.Bit, 1, "ppm_project_complete")
            insertCmd.Parameters.Add("@Id", SqlDbType.Int, 0, "PPM_Recordid")
            'The insert stored procedure (usp_ppm_insert_main) returns output param 'Id' from the SQL function return value of SCOPE_IDENTITY()
            'This is done to synchronize the datatable primary keys that where assigned in the identity field 
            'in the database (Increment seed) versus what the datatable (disconnected) started with
            insertCmd.Parameters("@Id").Direction = ParameterDirection.Output
            insertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters

            updateCmd.Connection = ProjectCon
            updateCmd.CommandText = "Publicworks.usp_ppm_update_main"
            updateCmd.CommandType = CommandType.StoredProcedure
            updateCmd.Parameters.Add("@PPM_Recordid", SqlDbType.Int, 4, "PPM_Recordid")
            updateCmd.Parameters.Add("@PPM_Project_Number", SqlDbType.NVarChar, 255, "PPM_Project_Number")
            updateCmd.Parameters.Add("@PPM_Project_Name", SqlDbType.NVarChar, 255, "PPM_Project_Name")
            updateCmd.Parameters.Add("@PPM_Active_Date", SqlDbType.SmallDateTime, 4, "PPM_Active_Date")
            updateCmd.Parameters.Add("@PPM_Inactive_Date", SqlDbType.SmallDateTime, 4, "PPM_Inactive_Date")
            updateCmd.Parameters.Add("@PPM_Project_Active", SqlDbType.Bit, 1, "PPM_Project_Active")
            updateCmd.Parameters.Add("@PPM_Status_Desc", SqlDbType.NVarChar, 3000, "PPM_Status_Desc")
            updateCmd.Parameters.Add("@PPM_Per_Des_Complete", SqlDbType.Int, 4, "PPM_Per_Des_Complete")
            updateCmd.Parameters.Add("@PPM_Proj_Scope", SqlDbType.NVarChar, 3000, "PPM_Proj_Scope")
            updateCmd.Parameters.Add("@PPM_MSA_Update", SqlDbType.Bit, 1, "PPM_MSA_Update")
            updateCmd.Parameters.Add("@PPM_Consultant_Fee", SqlDbType.Money, 8, "PPM_Consultant_Fee")
            updateCmd.Parameters.Add("@PPM_Contract_Amount", SqlDbType.Money, 8, "PPM_Contract_Amount")
            updateCmd.Parameters.Add("@PPM_Contract_Amendments", SqlDbType.Money, 8, "PPM_Contract_Amendments")
            updateCmd.Parameters.Add("@PPM_CO", SqlDbType.Money, 8, "PPM_CO")
            updateCmd.Parameters.Add("@PPM_Per_Const_Complete", SqlDbType.Int, 4, "PPM_Per_Const_Complete")
            updateCmd.Parameters.Add("@PPM_IFB_RFQ", SqlDbType.NVarChar, 255, "PPM_IFB_RFQ")
            updateCmd.Parameters.Add("@PPM_User_Letter", SqlDbType.Bit, 1, "PPM_User_Letter")
            updateCmd.Parameters.Add("@PPM_RFP_Number", SqlDbType.NVarChar, 50, "PPM_RFP_Number")
            updateCmd.Parameters.Add("@NDI_RFP", SqlDbType.SmallDateTime, 4, "NDI_RFP")
            updateCmd.Parameters.Add("@NDI_Scope", SqlDbType.SmallDateTime, 4, "NDI_Scope")
            updateCmd.Parameters.Add("@NDI_Advertise_for_Bid", SqlDbType.SmallDateTime, 4, "NDI_Advertise_for_Bid")
            updateCmd.Parameters.Add("@NDI_Original_Bid_Date", SqlDbType.SmallDateTime, 4, "NDI_Original_Bid_Date")
            updateCmd.Parameters.Add("@NDI_Bid_Opening", SqlDbType.SmallDateTime, 4, "NDI_Bid_Opening")
            updateCmd.Parameters.Add("@NDI_Design_Complete", SqlDbType.SmallDateTime, 4, "NDI_Design_Complete")
            updateCmd.Parameters.Add("@NDI_Gen_Serv_Review", SqlDbType.SmallDateTime, 4, "NDI_Gen_Serv_Review")
            updateCmd.Parameters.Add("@NDI_Consultant_Award", SqlDbType.SmallDateTime, 4, "NDI_Consultant_Award")
            updateCmd.Parameters.Add("@NDI_Construction_Bid_Award", SqlDbType.SmallDateTime, 4, "NDI_Construction_Bid_Award")
            updateCmd.Parameters.Add("@NDI_Agenda_Setting", SqlDbType.SmallDateTime, 4, "NDI_Agenda_Setting")
            updateCmd.Parameters.Add("@NDI_Assembly_Approval", SqlDbType.SmallDateTime, 4, "NDI_Assembly_Approval")
            updateCmd.Parameters.Add("@NDI_NTP", SqlDbType.SmallDateTime, 4, "NDI_NTP")
            updateCmd.Parameters.Add("@NDI_Substantial_Completion", SqlDbType.SmallDateTime, 4, "NDI_Substantial_Completion")
            updateCmd.Parameters.Add("@NDI_Final", SqlDbType.SmallDateTime, 4, "NDI_Final")
            updateCmd.Parameters.Add("@NDI_Warranty_Period_Ends", SqlDbType.SmallDateTime, 4, "NDI_Warranty_Period_Ends")
            updateCmd.Parameters.Add("@NDI_Closed", SqlDbType.SmallDateTime, 4, "NDI_Closed")
            updateCmd.Parameters.Add("@PPS_Recordid", SqlDbType.Int, 4, "PPS_Recordid")
            updateCmd.Parameters.Add("@PPU_Recordid", SqlDbType.Int, 4, "PPU_Recordid")
            updateCmd.Parameters.Add("@PPT_Recordid", SqlDbType.Int, 4, "PPT_Recordid")
            updateCmd.Parameters.Add("@PPR_Recordid", SqlDbType.Int, 4, "PPR_Recordid")
            updateCmd.Parameters.Add("@PPC_Recordid", SqlDbType.Int, 4, "PPC_Recordid")
            updateCmd.Parameters.Add("@PPA_Recordid", SqlDbType.Int, 4, "PPA_Recordid")
            updateCmd.Parameters.Add("@PPN_Recordid", SqlDbType.Int, 4, "PPN_Recordid")
            updateCmd.Parameters.Add("@NOU_Recordid", SqlDbType.Int, 4, "NOU_Recordid")
            updateCmd.Parameters.Add("@FFM_Recordid", SqlDbType.Int, 4, "FFM_Recordid")
            updateCmd.Parameters.Add("@PPM_Project_Complete", SqlDbType.Bit, 1, "ppm_project_complete")

            deleteCmd.Connection = ProjectCon
            deleteCmd.CommandText = "Publicworks.usp_ppm_delete_mainbyrecordid"
            deleteCmd.CommandType = CommandType.StoredProcedure
            deleteCmd.Parameters.Add("@PPM_Recordid", SqlDbType.Int, 4, "PPM_Recordid")

            ProjectsDA.InsertCommand = insertCmd
            ProjectsDA.UpdateCommand = updateCmd
            ProjectsDA.DeleteCommand = deleteCmd

            Dim i = ProjectsDA.Update(ProjectsDataTable)
            ProjectsDataTable.AcceptChanges()
            Return 0

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (insertCmd Is Nothing) Then
                    insertCmd.Dispose()
                End If
                If Not (ProjectsDA Is Nothing) Then
                    ProjectsDA.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function ProjectsUpdate(ByVal row As DataRow) As Integer

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As New ConnectionStringSettings
        Dim ProjectsDA As New SqlDataAdapter()
        Dim insertCmd As New SqlCommand()
        Dim updateCmd As New SqlCommand()
        Dim deleteCmd As New SqlCommand()

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            updateCmd.Connection = ProjectCon
            ProjectCon.Open()
            updateCmd.CommandText = "Publicworks.usp_ppm_update_main"
            updateCmd.CommandType = CommandType.StoredProcedure
            updateCmd.Parameters.Add("@PPM_Recordid", SqlDbType.Int, 4, "PPM_Recordid")
            updateCmd.Parameters.Add("@PPM_Project_Number", SqlDbType.NVarChar, 255, "PPM_Project_Number")
            updateCmd.Parameters.Add("@PPM_Project_Name", SqlDbType.NVarChar, 255, "PPM_Project_Name")
            updateCmd.Parameters.Add("@PPM_Active_Date", SqlDbType.SmallDateTime, 4, "PPM_Active_Date")
            updateCmd.Parameters.Add("@PPM_Inactive_Date", SqlDbType.SmallDateTime, 4, "PPM_Inactive_Date")
            updateCmd.Parameters.Add("@PPM_Project_Active", SqlDbType.Bit, 1, "PPM_Project_Active")
            updateCmd.Parameters.Add("@PPM_Status_Desc", SqlDbType.NVarChar, 3000, "PPM_Status_Desc")
            updateCmd.Parameters.Add("@PPM_Per_Des_Complete", SqlDbType.Int, 4, "PPM_Per_Des_Complete")
            updateCmd.Parameters.Add("@PPM_Proj_Scope", SqlDbType.NVarChar, 3000, "PPM_Proj_Scope")
            updateCmd.Parameters.Add("@PPM_MSA_Update", SqlDbType.Bit, 1, "PPM_MSA_Update")
            updateCmd.Parameters.Add("@PPM_Consultant_Fee", SqlDbType.Money, 8, "PPM_Consultant_Fee")
            updateCmd.Parameters.Add("@PPM_Contract_Amount", SqlDbType.Money, 8, "PPM_Contract_Amount")
            updateCmd.Parameters.Add("@PPM_Contract_Amendments", SqlDbType.Money, 8, "PPM_Contract_Amendments")
            updateCmd.Parameters.Add("@PPM_CO", SqlDbType.Money, 8, "PPM_CO")
            updateCmd.Parameters.Add("@PPM_Per_Const_Complete", SqlDbType.Int, 4, "PPM_Per_Const_Complete")
            updateCmd.Parameters.Add("@PPM_IFB_RFQ", SqlDbType.NVarChar, 255, "PPM_IFB_RFQ")
            updateCmd.Parameters.Add("@PPM_User_Letter", SqlDbType.Bit, 1, "PPM_User_Letter")
            updateCmd.Parameters.Add("@PPM_RFP_Number", SqlDbType.NVarChar, 50, "PPM_RFP_Number")
            updateCmd.Parameters.Add("@NDI_RFP", SqlDbType.SmallDateTime, 4, "NDI_RFP")
            updateCmd.Parameters.Add("@NDI_Scope", SqlDbType.SmallDateTime, 4, "NDI_Scope")
            updateCmd.Parameters.Add("@NDI_Advertise_for_Bid", SqlDbType.SmallDateTime, 4, "NDI_Advertise_for_Bid")
            updateCmd.Parameters.Add("@NDI_Original_Bid_Date", SqlDbType.SmallDateTime, 4, "NDI_Original_Bid_Date")
            updateCmd.Parameters.Add("@NDI_Bid_Opening", SqlDbType.SmallDateTime, 4, "NDI_Bid_Opening")
            updateCmd.Parameters.Add("@NDI_Design_Complete", SqlDbType.SmallDateTime, 4, "NDI_Design_Complete")
            updateCmd.Parameters.Add("@NDI_Gen_Serv_Review", SqlDbType.SmallDateTime, 4, "NDI_Gen_Serv_Review")
            updateCmd.Parameters.Add("@NDI_Consultant_Award", SqlDbType.SmallDateTime, 4, "NDI_Consultant_Award")
            updateCmd.Parameters.Add("@NDI_Construction_Bid_Award", SqlDbType.SmallDateTime, 4, "NDI_Construction_Bid_Award")
            updateCmd.Parameters.Add("@NDI_Agenda_Setting", SqlDbType.SmallDateTime, 4, "NDI_Agenda_Setting")
            updateCmd.Parameters.Add("@NDI_Assembly_Approval", SqlDbType.SmallDateTime, 4, "NDI_Assembly_Approval")
            updateCmd.Parameters.Add("@NDI_NTP", SqlDbType.SmallDateTime, 4, "NDI_NTP")
            updateCmd.Parameters.Add("@NDI_Substantial_Completion", SqlDbType.SmallDateTime, 4, "NDI_Substantial_Completion")
            updateCmd.Parameters.Add("@NDI_Final", SqlDbType.SmallDateTime, 4, "NDI_Final")
            updateCmd.Parameters.Add("@NDI_Warranty_Period_Ends", SqlDbType.SmallDateTime, 4, "NDI_Warranty_Period_Ends")
            updateCmd.Parameters.Add("@NDI_Closed", SqlDbType.SmallDateTime, 4, "NDI_Closed")
            updateCmd.Parameters.Add("@PPS_Recordid", SqlDbType.Int, 4, "PPS_Recordid")
            updateCmd.Parameters.Add("@PPU_Recordid", SqlDbType.Int, 4, "PPU_Recordid")
            updateCmd.Parameters.Add("@PPT_Recordid", SqlDbType.Int, 4, "PPT_Recordid")
            updateCmd.Parameters.Add("@PPR_Recordid", SqlDbType.Int, 4, "PPR_Recordid")
            updateCmd.Parameters.Add("@PPC_Recordid", SqlDbType.Int, 4, "PPC_Recordid")
            updateCmd.Parameters.Add("@PPA_Recordid", SqlDbType.Int, 4, "PPA_Recordid")
            updateCmd.Parameters.Add("@PPN_Recordid", SqlDbType.Int, 4, "PPN_Recordid")
            updateCmd.Parameters.Add("@NOU_Recordid", SqlDbType.Int, 4, "NOU_Recordid")
            updateCmd.Parameters.Add("@FFM_Recordid", SqlDbType.Int, 4, "FFM_Recordid")
            updateCmd.Parameters.Add("@ppm_project_complete", SqlDbType.BigInt, 4, "ppm_project_complete")
            ProjectsDA.UpdateCommand = updateCmd

            With updateCmd
                .Parameters("@PPM_Recordid").Value = row.Item(0)
                .Parameters("@PPM_Project_Active").Value = row.Item(1)
                .Parameters("@PPM_Project_Number").Value = row.Item(2)
                .Parameters("@PPM_Project_Name").Value = row.Item(3)
                .Parameters("@PPM_Active_Date").Value = row.Item(4)
                .Parameters("@PPM_Inactive_Date").Value = row.Item(5)
                .Parameters("@PPM_Per_Des_Complete").Value = row.Item(6)
                .Parameters("@PPM_Status_Desc").Value = row.Item(7)
                .Parameters("@PPM_Proj_Scope").Value = row.Item(8)
                .Parameters("@PPM_MSA_Update").Value = row.Item(9)
                .Parameters("@PPM_Consultant_Fee").Value = row.Item(10)
                .Parameters("@PPM_Contract_Amount").Value = row.Item(11)
                .Parameters("@PPM_Contract_Amendments").Value = row.Item(12)
                .Parameters("@PPM_CO").Value = row.Item(13)
                .Parameters("@PPM_Per_Const_Complete").Value = row.Item(14)
                .Parameters("@PPM_IFB_RFQ").Value = row.Item(15)
                .Parameters("@PPM_User_Letter").Value = row.Item(16)
                .Parameters("@PPM_RFP_Number").Value = row.Item(17)
                .Parameters("@NDI_RFP").Value = row.Item(18)
                .Parameters("@NDI_Scope").Value = row.Item(19)
                .Parameters("@NDI_Advertise_for_Bid").Value = row.Item(20)
                .Parameters("@NDI_Original_Bid_Date").Value = row.Item(21)
                .Parameters("@NDI_Bid_Opening").Value = row.Item(22)
                .Parameters("@NDI_Design_Complete").Value = row.Item(23)
                .Parameters("@NDI_Gen_Serv_Review").Value = row.Item(24)
                .Parameters("@NDI_Consultant_Award").Value = row.Item(25)
                .Parameters("@NDI_Construction_Bid_Award").Value = row.Item(26)
                .Parameters("@NDI_Agenda_Setting").Value = row.Item(27)
                .Parameters("@NDI_Assembly_Approval").Value = row.Item(28)
                .Parameters("@NDI_NTP").Value = row.Item(29)
                .Parameters("@NDI_Substantial_Completion").Value = row.Item(30)
                .Parameters("@NDI_Final").Value = row.Item(31)
                .Parameters("@NDI_Warranty_Period_Ends").Value = row.Item(32)
                .Parameters("@NDI_Closed").Value = row.Item(33)
                .Parameters("@PPS_Recordid").Value = row.Item(34)
                .Parameters("@PPU_Recordid").Value = row.Item(35)
                .Parameters("@PPT_Recordid").Value = row.Item(36)
                .Parameters("@PPR_Recordid").Value = row.Item(37)
                .Parameters("@PPC_Recordid").Value = row.Item(38)
                .Parameters("@PPA_Recordid").Value = row.Item(39)
                .Parameters("@PPN_Recordid").Value = row.Item(40)
                .Parameters("@NOU_Recordid").Value = row.Item(41)
                .Parameters("@FFM_Recordid").Value = row.Item(42)
                .Parameters("@ppm_project_complete").Value = row(43)
            End With

            updateCmd.ExecuteNonQuery()
            row.AcceptChanges()
            Return 0

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (insertCmd Is Nothing) Then
                    insertCmd.Dispose()
                End If
                If Not (ProjectsDA Is Nothing) Then
                    ProjectsDA.Dispose()
                End If
            End If
        End Try

    End Function




    Public Function FundingDelete(ByVal FundingDataTable As DataTable) As Integer

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectsDA As New SqlDataAdapter()
        Dim deleteCmd As New SqlCommand

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            deleteCmd.Connection = ProjectCon

            'Funding Delete Cmd
            deleteCmd.Connection = ProjectCon
            deleteCmd.CommandText = "usp_ppi_delete_funding"
            deleteCmd.CommandType = CommandType.StoredProcedure
            deleteCmd.Parameters.Add("@ppf_recordid", SqlDbType.Int, 4, "ppf_recordid")
            ProjectsDA.DeleteCommand = deleteCmd

            ProjectsDA.Update(FundingDataTable)
            FundingDataTable.AcceptChanges()  'forces the row state to be reset to unchanged
            Return 0

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (deleteCmd Is Nothing) Then
                    deleteCmd.Dispose()
                End If
                If Not (ProjectsDA Is Nothing) Then
                    ProjectsDA.Dispose()
                End If
            End If
        End Try


    End Function

    Public Function FundingUpdate(ByVal FundingDataTable As DataTable) As Integer

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectsDA As New SqlDataAdapter()
        Dim updateCmd As New SqlCommand
        Dim insertCmd As New SqlCommand
        Dim deleteCmd As New SqlCommand

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            updateCmd.Connection = ProjectCon
            updateCmd.CommandText = "Publicworks.usp_ppi_update_funding"
            updateCmd.CommandType = CommandType.StoredProcedure
            updateCmd.Parameters.Add("@ppf_funding", SqlDbType.NVarChar, 255, "ppf_funding")
            updateCmd.Parameters.Add("@ppf_department", SqlDbType.NVarChar, 255, "ppf_department")
            updateCmd.Parameters.Add("@ppf_glkey", SqlDbType.NVarChar, 255, "ppf_glkey")
            updateCmd.Parameters.Add("@ppf_glkey_name", SqlDbType.NVarChar, 255, "ppf_glkey_name")

            updateCmd.Parameters.Add("@ppf_budget", SqlDbType.Decimal, 21, "ppf_budget")
            updateCmd.Parameters("@ppf_budget").Precision = 19
            updateCmd.Parameters("@ppf_budget").Scale = 2

            updateCmd.Parameters.Add("@ppf_expenditures", SqlDbType.Decimal, 21, "ppf_expenditures")
            updateCmd.Parameters("@ppf_expenditures").Precision = 19
            updateCmd.Parameters("@ppf_expenditures").Scale = 2

            updateCmd.Parameters.Add("@ppf_encumbrances", SqlDbType.Decimal, 21, "ppf_encumbrances")
            updateCmd.Parameters("@ppf_encumbrances").Precision = 19
            updateCmd.Parameters("@ppf_encumbrances").Scale = 2

            updateCmd.Parameters.Add("@ppf_balance", SqlDbType.Decimal, 21, "ppf_balance")
            updateCmd.Parameters("@ppf_balance").Precision = 19
            updateCmd.Parameters("@ppf_balance").Scale = 2

            updateCmd.Parameters.Add("@ppm_recordid", SqlDbType.Int, 4, "ppm_recordid")
            updateCmd.Parameters.Add("@ppf_recordid", SqlDbType.Int, 4, "ppf_recordid")

            ProjectsDA.UpdateCommand = updateCmd
            insertCmd.Connection = ProjectCon
            insertCmd.CommandText = "Publicworks.usp_ppi_insert_funding"
            insertCmd.CommandType = CommandType.StoredProcedure
            insertCmd.Parameters.Add("@ppf_funding", SqlDbType.NVarChar, 255, "ppf_funding")
            insertCmd.Parameters.Add("@ppf_department", SqlDbType.NVarChar, 255, "ppf_department")
            insertCmd.Parameters.Add("@ppf_glkey", SqlDbType.NVarChar, 255, "ppf_glkey")
            insertCmd.Parameters.Add("@ppf_glkey_name", SqlDbType.NVarChar, 255, "ppf_glkey_name")
            insertCmd.Parameters.Add("@ppf_budget", SqlDbType.Decimal, 20, "ppf_budget")
            insertCmd.Parameters.Add("@ppf_expenditures", SqlDbType.Decimal, 20, "ppf_expenditures")
            insertCmd.Parameters.Add("@ppf_encumbrances", SqlDbType.Decimal, 20, "ppf_encumbrances")
            insertCmd.Parameters.Add("@ppf_balance", SqlDbType.Decimal, 20, "ppf_balance")
            insertCmd.Parameters.Add("@ppm_recordid", SqlDbType.Int, 4, "ppm_recordid")
            insertCmd.Parameters.Add("@Id", SqlDbType.Int, 0, "ppf_recordid")
            'The insert stored procedure (usp_ppi_insert_funding) returns output param 'Id' from the SQL function return value of SCOPE_IDENTITY()
            'This is done to synchronize the datatable primary keys that where assigned in the identity field 
            'in the database (Increment seed) versus what the datatable (disconnected) started with
            insertCmd.Parameters("@Id").Direction = ParameterDirection.Output
            insertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
            ProjectsDA.InsertCommand = insertCmd
            Dim updateout = ProjectsDA.Update(FundingDataTable)
            FundingDataTable.AcceptChanges()  'forces the row state to be reset to unchanged
            Return updateout

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (insertCmd Is Nothing) Then
                    insertCmd.Dispose()
                End If
                If Not (updateCmd Is Nothing) Then
                    updateCmd.Dispose()
                End If
                If Not (ProjectsDA Is Nothing) Then
                    ProjectsDA.Dispose()
                End If
            End If
        End Try

    End Function

    Public Function FundingRowsUpdate(ByVal fundsDataRows() As DataRow) As Integer

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim insertCmd As New SqlCommand

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            insertCmd.Connection = ProjectCon
            insertCmd.CommandText = "Publicworks.usp_ppi_insert_funding"
            insertCmd.CommandType = CommandType.StoredProcedure
            ProjectCon.Open()

            With insertCmd.Parameters
                .Add("@ppf_funding", SqlDbType.NVarChar, 255, "ppf_funding")
                .Add("@ppf_department", SqlDbType.NVarChar, 255, "ppf_department")
                .Add("@ppf_glkey", SqlDbType.NVarChar, 255, "ppf_glkey")
                .Add("@ppf_glkey_name", SqlDbType.NVarChar, 255, "ppf_glkey_name")
                .Add("@ppf_budget", SqlDbType.Decimal, 9, "ppf_budget")
                .Add("@ppf_expenditures", SqlDbType.Decimal, 9, "ppf_expenditures")
                .Add("@ppf_encumbrances", SqlDbType.Decimal, 9, "ppf_encumbrances")
                .Add("@ppf_balance", SqlDbType.Decimal, 9, "ppf_balance")
                .Add("@ppm_recordid", SqlDbType.Int, 4, "ppm_recordid")
                .Add("@Id", SqlDbType.Int, 0, "ppf_recordid")
            End With

            insertCmd.Parameters("@Id").Direction = ParameterDirection.Output
            insertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters

            For Each row In fundsDataRows
                With insertCmd
                    .Parameters("@ppf_funding").Value = row.Item(0)      'PPI_Fund
                    .Parameters("@ppf_department").Value = row.Item(1)      'PPI_Department
                    .Parameters("@ppf_glkey").Value = row.Item(2)      'PPI_GL
                    .Parameters("@ppf_glkey_name").Value = row.Item(3)      'PPI_GL_Long_Name
                    .Parameters("@ppf_budget").Value = row.Item(4)      'PPI_Project_Budget
                    .Parameters("@ppf_expenditures").Value = row.Item(5)      'PPI_LTD_Expenditures
                    .Parameters("@ppf_encumbrances").Value = row.Item(6)      'PPI_Encumbrances
                    .Parameters("@ppf_balance").Value = row.Item(7)      'PPI_Available_Balance
                    .Parameters("@ppm_recordid").Value = row.Item(8)     'PPM_Recordid
                End With

                insertCmd.ExecuteNonQuery()
                row.AcceptChanges()
            Next

            ProjectCon.Close()

            'The insert stored procedure (usp_ppi_insert_funding) returns output param 'Id' from the SQL function return value of SCOPE_IDENTITY()
            'This is done to synchronize the datatable primary keys that where assigned in the identity field 
            'in the database (Increment seed) versus what the datatable (disconnected) started with
            'insertCmd.Parameters("@Id").Direction = ParameterDirection.Output
            'insertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters

            Return 0

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (insertCmd Is Nothing) Then
                    insertCmd.Dispose()
                End If
            End If
        End Try

    End Function

    Public Function FundingRowsDelete(ByVal FundDeleteRecordID) As Integer

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim deleteCmd As New SqlCommand

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            'Funding Delete Cmd
            deleteCmd.Connection = ProjectCon
            deleteCmd.CommandText = "Publicworks.usp_ppi_delete_funding"
            deleteCmd.CommandType = CommandType.StoredProcedure

            ProjectCon.Open()
            deleteCmd.Parameters.Add("@ppf_recordid", SqlDbType.Int, 4, "ppf_recordid")

            deleteCmd.Parameters(0).Value = FundDeleteRecordID      'PPI_Recordid
            deleteCmd.ExecuteNonQuery()

            ProjectCon.Close()
            Return 0

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (deleteCmd Is Nothing) Then
                    deleteCmd.Dispose()
                End If
            End If
        End Try

    End Function


    ''' <summary>
    ''' ProjectsMiniView returns an abbreviated full Projects list instead of the full return of all data.
    ''' Includes the recordid, project name, project number, project status, and project description.
    ''' </summary>
    ''' <param name="Project"></param>
    ''' <param name="SQL"></param>
    ''' <returns></returns>
    ''' <remarks>Used in the funding add sequence - do not delete (yet)</remarks>
    Public Function ProjectsMiniView(ByVal Project As PublicWorks.Type, ByVal SQL As String) As DataTable

        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim ProjectsDA As New SqlDataAdapter
        Dim PublicWorksConnection As ConnectionStringSettings
        ProjectsMiniView = New DataTable

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            selectCmd.Connection = ProjectCon
            selectCmd.CommandText = SQL
            selectCmd.CommandType = CommandType.StoredProcedure
            ProjectsDA.SelectCommand = selectCmd
            ProjectsDA.Fill(ProjectsMiniView)
            Return ProjectsMiniView
        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
                If Not (ProjectsDA Is Nothing) Then
                    ProjectsDA.Dispose()
                End If
            End If
        End Try

    End Function

    ''' <summary>
    ''' ProjectFunding loads all the funding records into a datatable
    ''' </summary>
    ''' <param name="CommandSQL"></param>
    ''' <returns></returns>
    ''' <remarks>sort and filtering on front</remarks>
    Public Function ProjectFunding(ByVal CommandSQL As String) As DataTable

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim selectCmd As New SqlCommand
        Dim ProjectDA As New SqlDataAdapter
        ProjectFunding = New DataTable

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            selectCmd.Connection = ProjectCon
            selectCmd.CommandText = CommandSQL
            selectCmd.CommandType = CommandType.StoredProcedure
            ProjectDA.SelectCommand = selectCmd
            ProjectDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            ProjectDA.Fill(ProjectFunding)

            ProjectFunding.Columns("ppf_budget").DefaultValue = 0D
            ProjectFunding.Columns("ppf_expenditures").DefaultValue = 0D
            ProjectFunding.Columns("ppf_encumbrances").DefaultValue = 0D
            ProjectFunding.Columns("ppf_balance").DefaultValue = 0D


            ProjectFunding.PrimaryKey = New DataColumn() {ProjectFunding.Columns("ppf_recordid")}
            Return ProjectFunding

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
                If Not (ProjectDA Is Nothing) Then
                    ProjectDA.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function ProjectPhoto(ByVal CommandSQL As String) As DataTable

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectDA As New SqlDataAdapter
        Dim ProjectCom As New SqlCommand
        ProjectPhoto = New DataTable

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCom.Connection = ProjectCon
            ProjectCom.CommandText = CommandSQL
            ProjectCom.CommandType = CommandType.StoredProcedure
            ProjectDA.SelectCommand = ProjectCom
            ProjectDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            ProjectDA.Fill(ProjectPhoto)
            Return ProjectPhoto

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (ProjectCom Is Nothing) Then
                    ProjectCom.Dispose()
                End If
                If Not (ProjectDA Is Nothing) Then
                    ProjectDA.Dispose()
                End If
            End If
        End Try

    End Function

    Public Function LoadProjectUsers(ByVal CommandSQL As String) As DataTable

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectDA As New SqlDataAdapter
        Dim ProjectCom As New SqlCommand
        LoadProjectUsers = New DataTable

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCom.Connection = ProjectCon
            ProjectCom.CommandText = CommandSQL
            ProjectCom.CommandType = CommandType.StoredProcedure
            ProjectDA.SelectCommand = ProjectCom
            ProjectDA = New SqlDataAdapter(ProjectCom)
            ProjectDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            ProjectDA.Fill(LoadProjectUsers)
            Return LoadProjectUsers

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (ProjectCom Is Nothing) Then
                    ProjectCom.Dispose()
                End If
                If Not (ProjectDA Is Nothing) Then
                    ProjectDA.Dispose()
                End If
            End If
        End Try

    End Function


    ' ''' <summary>
    ' ''' Test routing to save a demo file to the database
    ' ''' </summary>
    ' ''' <remarks></remarks>
    ' Public Sub PhotosTestSave()

    '   Dim ProjectCon As New SqlConnection
    '   Dim PublicWorksConnection As ConnectionStringSettings

    'PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
    '   ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString

    '   Dim cn As New SqlConnection(ProjectCon.ConnectionString)

    '   Dim cmd As New SqlCommand("INSERT INTO Publicworks_Project_Photo (ppp_image, ppm_recordid) " & _
    '       "VALUES (@ppp_Image, @ppm_recordid)", cn)

    '   Dim strBLOBFilePath As String = "C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\winter.jpg"
    '   Dim fsBLOBFile As New IO.FileStream(strBLOBFilePath, IO.FileMode.Open, IO.FileAccess.Read)
    '   Dim bytBLOBData(CInt(fsBLOBFile.Length() - 1)) As Byte
    '   fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length)
    '   fsBLOBFile.Close()


    '   Dim prm As New SqlParameter("@ppp_Image", SqlDbType.Image, bytBLOBData.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, bytBLOBData)

    '   Dim prm1 As New SqlParameter("@ppm_recordid", SqlDbType.Int, 4, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, 5261)

    '   cmd.Parameters.Add(prm)
    '   cmd.Parameters.Add(prm1)

    '   cn.Open()
    '   cmd.ExecuteNonQuery()
    '   cn.Close()


    ' End Sub

    Public Function PhotosUpdate(ByVal PhotosDataTable As DataTable) As Integer

        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim PhotosDA As New SqlDataAdapter()
        Dim InsertCmd As New SqlCommand
        Dim UpdateCmd As New SqlCommand
        Dim DeleteCmd As New SqlCommand
        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            InsertCmd.Connection = ProjectCon
            InsertCmd.CommandText = "usp_ppp_insert_photos"
            InsertCmd.CommandType = CommandType.StoredProcedure
            InsertCmd.Parameters.Add("@ppp_imageloc", SqlDbType.VarChar, 255, "ppp_imageloc")
            InsertCmd.Parameters.Add("@ppp_imagetitle", SqlDbType.VarChar, 50, "ppp_imagetitle")
            InsertCmd.Parameters.Add("@ppp_imagedesc", SqlDbType.VarChar, 255, "ppp_imagedesc")
            InsertCmd.Parameters.Add("@ppp_imagedate", SqlDbType.SmallDateTime, 4, "ppp_imagedate")
            InsertCmd.Parameters.Add("@ppp_imageheight", SqlDbType.Int, 4, "ppp_imageheight")
            InsertCmd.Parameters.Add("@ppp_imagewidth", SqlDbType.Int, 4, "ppp_imagewidth")
            InsertCmd.Parameters.Add("@ppm_recordid", SqlDbType.Int, 4, "ppm_recordid")
            PhotosDA.InsertCommand = InsertCmd

            'Photo Update Command
            UpdateCmd.Connection = ProjectCon
            UpdateCmd.CommandText = "usp_ppp_update_photos"
            UpdateCmd.CommandType = CommandType.StoredProcedure

            UpdateCmd.Parameters.Add("@ppp_recordid", SqlDbType.Int, 4, "ppp_recordid")
            UpdateCmd.Parameters.Add("@ppp_imageloc", SqlDbType.VarChar, 255, "ppp_imageloc")
            UpdateCmd.Parameters.Add("@ppp_imagetitle", SqlDbType.VarChar, 50, "ppp_imagetitle")
            UpdateCmd.Parameters.Add("@ppp_imagedesc", SqlDbType.VarChar, 255, "ppp_imagedesc")
            UpdateCmd.Parameters.Add("@ppp_imagedate", SqlDbType.SmallDateTime, 4, "ppp_imagedate")
            UpdateCmd.Parameters.Add("@ppp_imageheight", SqlDbType.Int, 4, "ppp_imageheight")
            UpdateCmd.Parameters.Add("@ppp_imagewidth", SqlDbType.Int, 4, "ppp_imagewidth")
            UpdateCmd.Parameters.Add("@ppm_recordid", SqlDbType.Int, 4, "ppm_recordid")
            PhotosDA.UpdateCommand = UpdateCmd

            'Photo Delete Command
            DeleteCmd.Connection = ProjectCon
            DeleteCmd.CommandText = "usp_ppp_delete_photos"
            DeleteCmd.CommandType = CommandType.StoredProcedure
            DeleteCmd.Parameters.Add("@ppp_recordid", SqlDbType.Int, 4, "PPI_Recordid")
            PhotosDA.DeleteCommand = DeleteCmd
            PhotosDA.Update(PhotosDataTable)
            PhotosDataTable.AcceptChanges()
            PhotosUpdate = 0
        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (InsertCmd Is Nothing) Then
                    InsertCmd.Dispose()
                End If
                If Not (UpdateCmd Is Nothing) Then
                    InsertCmd.Dispose()
                End If
                If Not (DeleteCmd Is Nothing) Then
                    InsertCmd.Dispose()
                End If
                If Not (PhotosDA Is Nothing) Then
                    PhotosDA.Dispose()
                End If
            End If
        End Try

    End Function

    Public Sub EntityUpdate(ByVal EntityTable As DataTable)


        Dim ProjectCon As New SqlConnection
        Dim PublicWorksConnection As ConnectionStringSettings
        Dim EntityDA As New SqlDataAdapter()
        Dim InsertCmd As New SqlCommand
        Dim UpdateCmd As New SqlCommand
        Dim DeleteCmd As New SqlCommand

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString

            Select Case EntityTable.TableName
                Case "architect"  'Architect  / Engineer -----------------------------------------------------
                    InsertCmd.Connection = ProjectCon
                    InsertCmd.CommandText = "usp_ppa_arceng_insert"    'updated SQL05
                    InsertCmd.CommandType = CommandType.StoredProcedure
                    InsertCmd.Parameters.Add("@PPA_LastName", SqlDbType.NVarChar, 50, "PPA_LastName")
                    InsertCmd.Parameters.Add("@PPA_FirstName", SqlDbType.VarChar, 50, "PPA_FirstName")
                    InsertCmd.Parameters.Add("@Id", SqlDbType.Int, 4, "PPA_Recordid")
                    InsertCmd.Parameters("@Id").Direction = ParameterDirection.Output
                    InsertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
                    EntityDA.InsertCommand = InsertCmd

                    UpdateCmd.Connection = ProjectCon
                    UpdateCmd.CommandText = "usp_ppa_arceng_update"    'updated SQL05
                    UpdateCmd.CommandType = CommandType.StoredProcedure
                    UpdateCmd.Parameters.Add("@PPA_Recordid", SqlDbType.Int, 4, "PPA_Recordid")
                    UpdateCmd.Parameters.Add("@PPA_LastName", SqlDbType.NVarChar, 50, "PPA_LastName")
                    UpdateCmd.Parameters.Add("@PPA_FirstName", SqlDbType.VarChar, 50, "PPA_FirstName")
                    EntityDA.UpdateCommand = UpdateCmd

                    DeleteCmd.Connection = ProjectCon
                    DeleteCmd.CommandText = "usp_ppa_arceng_delete"    'updated SQL05
                    DeleteCmd.CommandType = CommandType.StoredProcedure
                    DeleteCmd.Parameters.Add("@PPA_Recordid", SqlDbType.Int, 4, "PPA_Recordid")
                    EntityDA.DeleteCommand = DeleteCmd

                Case "secretary"  'Secretary -----------------------------------------------------------------
                    InsertCmd.Connection = ProjectCon
                    InsertCmd.CommandText = "usp_pps_secretary_insert"    'updated SQL05
                    InsertCmd.CommandType = CommandType.StoredProcedure
                    With InsertCmd.Parameters
                        .Add("@PPS_Secretary", SqlDbType.NVarChar, 255, "PPS_Secretary")
                        .Add("@PPS_LastName", SqlDbType.NVarChar, 50, "PPS_LastName")
                        .Add("@PPS_FirstName", SqlDbType.VarChar, 50, "PPS_FirstName")
                        .Add("@PPS_Signature_Name", SqlDbType.VarChar, 255, "PPS_Signature_Name")
                        .Add("@PPS_Title", SqlDbType.VarChar, 255, "PPS_Title")
                        .Add("@id", SqlDbType.Int, 4, "PPS_Recordid")
                    End With
                    InsertCmd.Parameters("@Id").Direction = ParameterDirection.Output
                    InsertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
                    EntityDA.InsertCommand = InsertCmd

                    UpdateCmd.Connection = ProjectCon
                    UpdateCmd.CommandText = "usp_pps_secretary_update"
                    UpdateCmd.CommandType = CommandType.StoredProcedure
                    With UpdateCmd.Parameters
                        .Add("@PPS_Recordid", SqlDbType.Int, 4, "PPS_Recordid")
                        .Add("@PPS_Secretary", SqlDbType.NVarChar, 255, "PPS_Secretary")
                        .Add("@PPS_LastName", SqlDbType.NVarChar, 50, "PPS_LastName")
                        .Add("@PPS_FirstName", SqlDbType.VarChar, 50, "PPS_FirstName")
                        .Add("@PPS_Signature_Name", SqlDbType.VarChar, 255, "PPS_Signature_Name")
                        .Add("@PPS_Title", SqlDbType.VarChar, 255, "PPS_Title")
                    End With
                    EntityDA.UpdateCommand = UpdateCmd

                    DeleteCmd.Connection = ProjectCon
                    DeleteCmd.CommandText = "usp_pps_secretary_delete"
                    DeleteCmd.CommandType = CommandType.StoredProcedure
                    DeleteCmd.Parameters.Add("@PPS_Recordid", SqlDbType.Int, 4, "PPS_Recordid")
                    EntityDA.DeleteCommand = DeleteCmd

                Case "manager"  'Manager ------------------------------------------------------------

                    InsertCmd.Connection = ProjectCon
                    InsertCmd.CommandText = "usp_ppr_manager_insert"    'updated SQL05
                    InsertCmd.CommandType = CommandType.StoredProcedure
                    With InsertCmd.Parameters
                        .Add("@PPR_Signature_Name", SqlDbType.VarChar, 255, "PPR_Signature_Name")
                        .Add("@PPR_Title", SqlDbType.NVarChar, 255, "PPR_Title")
                        .Add("@PPR_LastName", SqlDbType.NVarChar, 50, "PPR_LastName")
                        .Add("@PPR_FirstName", SqlDbType.VarChar, 50, "PPR_FirstName")
                        .Add("@Id", SqlDbType.Int, 4, "PPR_Recordid")
                    End With
                    InsertCmd.Parameters("@Id").Direction = ParameterDirection.Output
                    InsertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
                    EntityDA.InsertCommand = InsertCmd

                    UpdateCmd.Connection = ProjectCon
                    UpdateCmd.CommandText = "usp_ppr_manager_update"
                    UpdateCmd.CommandType = CommandType.StoredProcedure
                    With UpdateCmd.Parameters
                        .Add("@PPR_Recordid", SqlDbType.Int, 4, "PPR_Recordid")
                        .Add("@PPR_Signature_Name", SqlDbType.VarChar, 255, "PPR_Signature_Name")
                        .Add("@PPR_Title", SqlDbType.NVarChar, 255, "PPR_Title")
                        .Add("@PPR_LastName", SqlDbType.NVarChar, 50, "PPR_LastName")
                        .Add("@PPR_FirstName", SqlDbType.VarChar, 50, "PPR_FirstName")
                    End With
                    EntityDA.UpdateCommand = UpdateCmd

                    DeleteCmd.Connection = ProjectCon
                    DeleteCmd.CommandText = "usp_ppr_manager_delete"
                    DeleteCmd.CommandType = CommandType.StoredProcedure
                    DeleteCmd.Parameters.Add("@PPR_Recordid", SqlDbType.Int, 4, "PPR_Recordid")
                    EntityDA.DeleteCommand = DeleteCmd

                Case "user" 'User -------------------------------------------------------------------

                    InsertCmd.Connection = ProjectCon
                    InsertCmd.CommandText = "usp_ppu_user_insert"    'updated SQL05
                    InsertCmd.CommandType = CommandType.StoredProcedure
                    With InsertCmd.Parameters
                        .Add("@PPU_FirstName", SqlDbType.NVarChar, 255, "PPU_FirstName")
                        .Add("@PPU_LastName", SqlDbType.NVarChar, 255, "PPU_LastName")
                        .Add("@PPU_Title", SqlDbType.NVarChar, 255, "PPU_Title")
                        .Add("@PPU_Department", SqlDbType.NVarChar, 255, "PPU_Department")
                        .Add("@PPU_Company", SqlDbType.NVarChar, 255, "PPU_Company")
                        .Add("@PPU_Address", SqlDbType.NVarChar, 255, "PPU_Address")
                        .Add("@PPU_City", SqlDbType.NVarChar, 255, "PPU_City")
                        .Add("@PPU_State", SqlDbType.NVarChar, 255, "PPU_State")
                        .Add("@PPU_Zip", SqlDbType.NVarChar, 255, "PPU_Zip")
                        .Add("@Id", SqlDbType.Int, 0, "PPU_Recordid")
                    End With
                    InsertCmd.Parameters("@Id").Direction = ParameterDirection.Output
                    InsertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
                    EntityDA.InsertCommand = InsertCmd

                    UpdateCmd.Connection = ProjectCon
                    UpdateCmd.CommandText = "usp_ppu_user_update"
                    UpdateCmd.CommandType = CommandType.StoredProcedure
                    With UpdateCmd.Parameters
                        .Add("@PPU_Recordid", SqlDbType.Int, 0, "PPU_Recordid")
                        .Add("@PPU_FirstName", SqlDbType.NVarChar, 255, "PPU_FirstName")
                        .Add("@PPU_LastName", SqlDbType.NVarChar, 255, "PPU_LastName")
                        .Add("@PPU_Title", SqlDbType.NVarChar, 255, "PPU_Title")
                        .Add("@PPU_Department", SqlDbType.NVarChar, 255, "PPU_Department")
                        .Add("@PPU_Company", SqlDbType.NVarChar, 255, "PPU_Company")
                        .Add("@PPU_Address", SqlDbType.NVarChar, 255, "PPU_Address")
                        .Add("@PPU_City", SqlDbType.NVarChar, 255, "PPU_City")
                        .Add("@PPU_State", SqlDbType.NVarChar, 255, "PPU_State")
                        .Add("@PPU_Zip", SqlDbType.NVarChar, 255, "PPU_Zip")
                    End With
                    EntityDA.UpdateCommand = UpdateCmd

                    DeleteCmd.Connection = ProjectCon
                    DeleteCmd.CommandText = "usp_ppu_user_delete"
                    DeleteCmd.CommandType = CommandType.StoredProcedure
                    DeleteCmd.Parameters.Add("@PPU_Recordid", SqlDbType.Int, 4, "PPU_Recordid")
                    EntityDA.DeleteCommand = DeleteCmd

                Case "types" 'Project Type ------------------------------------------------------

                    InsertCmd.Connection = ProjectCon
                    InsertCmd.CommandText = "usp_ppt_projecttype_insert"    'updated SQL05
                    InsertCmd.CommandType = CommandType.StoredProcedure
                    With InsertCmd.Parameters
                        .Add("@npt_type", SqlDbType.NVarChar, 255, "npt_type")
                        .Add("@Id", SqlDbType.Int, 4, "npt_recordid")
                    End With
                    InsertCmd.Parameters("@Id").Direction = ParameterDirection.Output
                    InsertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
                    EntityDA.InsertCommand = InsertCmd

                    UpdateCmd.Connection = ProjectCon
                    UpdateCmd.CommandText = "usp_ppt_projecttype_update"
                    UpdateCmd.CommandType = CommandType.StoredProcedure
                    With UpdateCmd.Parameters
                        .Add("@npt_recordid", SqlDbType.Int, 4, "npt_recordid")
                        .Add("@npt_type", SqlDbType.NVarChar, 255, "npt_type")
                    End With
                    EntityDA.UpdateCommand = UpdateCmd

                    DeleteCmd.Connection = ProjectCon
                    DeleteCmd.CommandText = "usp_ppt_projecttype_delete"
                    DeleteCmd.CommandType = CommandType.StoredProcedure
                    DeleteCmd.Parameters.Add("@npt_recordid", SqlDbType.Int, 4, "npt_recordid")
                    EntityDA.DeleteCommand = DeleteCmd

                Case "contractor"

                    InsertCmd.Connection = ProjectCon
                    InsertCmd.CommandText = "usp_ncn_contractor_insert"    'updated SQL05
                    InsertCmd.CommandType = CommandType.StoredProcedure
                    With InsertCmd.Parameters
                        .Add("@ncn_contractor", SqlDbType.NVarChar, 255, "ncn_contractor")
                        .Add("@Id", SqlDbType.Int, 4, "ncn_recordid")
                    End With
                    InsertCmd.Parameters("@Id").Direction = ParameterDirection.Output
                    InsertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
                    EntityDA.InsertCommand = InsertCmd

                    UpdateCmd.Connection = ProjectCon
                    UpdateCmd.CommandText = "usp_ncn_contractor_update"
                    UpdateCmd.CommandType = CommandType.StoredProcedure
                    With UpdateCmd.Parameters
                        .Add("@ncn_contractor", SqlDbType.Int, 4, "ncn_contractor")
                        .Add("@ncn_recordid", SqlDbType.NVarChar, 255, "ncn_recordid")
                    End With
                    EntityDA.UpdateCommand = UpdateCmd

                    DeleteCmd.Connection = ProjectCon
                    DeleteCmd.CommandText = "usp_ncn_contractor_delete"
                    DeleteCmd.CommandType = CommandType.StoredProcedure
                    DeleteCmd.Parameters.Add("@ncn_recordid", SqlDbType.Int, 4, "ncn_recordid")
                    EntityDA.DeleteCommand = DeleteCmd

                Case "consultant"

                    InsertCmd.Connection = ProjectCon
                    InsertCmd.CommandText = "usp_npc_consultant_insert"    'updated SQL05
                    InsertCmd.CommandType = CommandType.StoredProcedure
                    With InsertCmd.Parameters
                        .Add("@npc_contractor", SqlDbType.NVarChar, 255, "npc_contractor")
                        .Add("@Id", SqlDbType.Int, 4, "npc_recordid")
                    End With
                    InsertCmd.Parameters("@Id").Direction = ParameterDirection.Output
                    InsertCmd.UpdatedRowSource = UpdateRowSource.OutputParameters
                    EntityDA.InsertCommand = InsertCmd

                    UpdateCmd.Connection = ProjectCon
                    UpdateCmd.CommandText = "usp_npc_consultant_update"
                    UpdateCmd.CommandType = CommandType.StoredProcedure
                    With UpdateCmd.Parameters
                        .Add("@npc_contractor", SqlDbType.Int, 4, "npc_contractor")
                        .Add("@npc_recordid", SqlDbType.NVarChar, 255, "npc_recordid")
                    End With
                    EntityDA.UpdateCommand = UpdateCmd

                    DeleteCmd.Connection = ProjectCon
                    DeleteCmd.CommandText = "usp_npc_consultant_delete"
                    DeleteCmd.CommandType = CommandType.StoredProcedure
                    DeleteCmd.Parameters.Add("@npc_recordid", SqlDbType.Int, 4, "npc_recordid")
                    EntityDA.DeleteCommand = DeleteCmd
            End Select

            EntityDA.Update(EntityTable)
            EntityTable.AcceptChanges()

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (InsertCmd Is Nothing) Then
                    InsertCmd.Dispose()
                End If
                If Not (UpdateCmd Is Nothing) Then
                    InsertCmd.Dispose()
                End If
                If Not (DeleteCmd Is Nothing) Then
                    InsertCmd.Dispose()
                End If
                If Not (EntityDA Is Nothing) Then
                    EntityDA.Dispose()
                End If
            End If
        End Try

    End Sub

    ''' <summary>
    ''' ProjectsMiniView returns an abbreviated full Projects list instead of the full return of all data.
    ''' Includes the recordid, project name, project number, project status, and project description.
    ''' </summary>
    ''' <param name="SQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ProjectsMiniView(ByVal SQL As String) As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim ProjectDA As New SqlDataAdapter
        Dim selectCmd As SqlCommand = ProjectCon.CreateCommand
        ProjectsMiniView = New DataTable

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = SQL
            ProjectDA.SelectCommand = selectCmd
            ProjectDA.Fill(ProjectsMiniView)

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
                If Not (ProjectDA Is Nothing) Then
                    ProjectDA.Dispose()
                End If
            End If
        End Try

    End Function

    Public Function ProjectManagerTable() As DataTable

        'PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
        'ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        ProjectManagerTable = New DataTable
        Dim Reader As SqlDataReader
        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_ppr_manager_selectall"
            Reader = selectCmd.ExecuteReader()

            Using Reader
                If Reader.HasRows = True Then
                    ProjectManagerTable.Load(Reader)
                    ProjectManagerTable.PrimaryKey = New DataColumn() {ProjectManagerTable.Columns(0)}
                    Reader.Close()
                End If
            End Using

            Return ProjectManagerTable

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function ProjectConsultantTable() As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim Reader As SqlDataReader
        ProjectConsultantTable = New DataTable

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_npc_consultant_selectall"
            Reader = selectCmd.ExecuteReader()

            Using Reader
                If Reader.HasRows = True Then
                    ProjectConsultantTable.Load(Reader)
                    ProjectConsultantTable.PrimaryKey = New DataColumn() {ProjectConsultantTable.Columns(0)}
                    Reader.Close()
                End If
            End Using

            Return ProjectConsultantTable

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function ProjectContractorTable() As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim Reader As SqlDataReader
        ProjectContractorTable = New DataTable

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_ncn_contractor_selectall"
            Reader = selectCmd.ExecuteReader()

            Using Reader
                If Reader.HasRows = True Then
                    ProjectContractorTable.Load(Reader)
                    ProjectContractorTable.PrimaryKey = New DataColumn() {ProjectContractorTable.Columns(0)}
                    Reader.Close()
                End If
            End Using

            Return ProjectContractorTable

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function ProjectArchitectTable() As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim Reader As SqlDataReader
        ProjectArchitectTable = New DataTable

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_ppa_arcengname_selectall"
            Reader = selectCmd.ExecuteReader(CommandBehavior.KeyInfo)

            Using Reader
                If Reader.HasRows = True Then
                    ProjectArchitectTable.Load(Reader)
                    ProjectArchitectTable.PrimaryKey = New DataColumn() {ProjectArchitectTable.Columns(0)}
                    Reader.Close()
                End If
            End Using

            Return ProjectArchitectTable

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try

    End Function

    Public Function ProjectSecretaryTable() As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim Reader As SqlDataReader
        ProjectSecretaryTable = New DataTable


        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_pps_secretaryname_selectall"
            Reader = selectCmd.ExecuteReader(CommandBehavior.KeyInfo)

            Using Reader
                If Reader.HasRows = True Then
                    ProjectSecretaryTable.Load(Reader)
                    ProjectSecretaryTable.PrimaryKey = New DataColumn() {ProjectSecretaryTable.Columns(0)}
                    Reader.Close()
                End If
            End Using

            Return ProjectSecretaryTable

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try

    End Function



    Public Function ProjectTypeTable() As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim Reader As SqlDataReader
        ProjectTypeTable = New DataTable

        Try
            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_ppt_projecttype_selectall"
            Reader = selectCmd.ExecuteReader()

            Using Reader
                If Reader.HasRows = True Then
                    ProjectTypeTable.Load(Reader)
                    ProjectTypeTable.PrimaryKey = New DataColumn() {ProjectTypeTable.Columns(0)}
                    Reader.Close()
                End If
            End Using

            Return ProjectTypeTable

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try

    End Function

    Public Function ProjectUserTable() As DataTable

        Dim PublicWorksConnection As ConnectionStringSettings
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim Reader As SqlDataReader
        ProjectUserTable = New DataTable

        Try

            PublicWorksConnection = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = PublicWorksConnection.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_ppu_user_selectall"
            Reader = selectCmd.ExecuteReader(CommandBehavior.KeyInfo)

            Using Reader
                If Reader.HasRows = True Then
                    ProjectUserTable.Load(Reader)
                    ProjectUserTable.PrimaryKey = New DataColumn() {ProjectUserTable.Columns(0)}
                    Reader.Close()
                End If
            End Using

            Return ProjectUserTable

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try

    End Function


    Public Function LoadManagerHash() As Dictionary(Of String, Integer)

        Dim Reader As SqlDataReader
        Dim ProjectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim pubs As ConnectionStringSettings

        Try
            pubs = ConfigurationManager.ConnectionStrings(PWC)
            ProjectCon.ConnectionString = pubs.ConnectionString
            ProjectCon.Open()
            selectCmd.Connection = ProjectCon
            selectCmd.CommandType = CommandType.StoredProcedure
            selectCmd.CommandText = "usp_ppr_manager_selectall"
            Reader = selectCmd.ExecuteReader(CommandBehavior.KeyInfo)

            Using Reader
                Do While Reader.Read
                    If IsDBNull(Reader.Item(4)) Then
                        LoadManagerHash.Add(Reader.Item(0), Reader.Item(3))
                    Else
                        LoadManagerHash.Add(Reader.Item(0), Reader.Item(3) & ", " & Reader.Item(4))
                    End If
                Loop
            End Using

        Catch Ex As SqlException
            MessageBox.Show(Ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            If Not (ProjectCon Is Nothing) Then
                If (ProjectCon.State = ConnectionState.Open) Then
                    ProjectCon.Close()
                End If
                ProjectCon.Dispose()
                If Not (selectCmd Is Nothing) Then
                    selectCmd.Dispose()
                End If
            End If
        End Try


    End Function


    Public Function LoadSecretaryHash() As Hashtable

        Dim Reader As SqlDataReader
        LoadSecretaryHash = New Hashtable
        Dim ProjectCon As New SqlConnection
        Dim ProjectCom As New SqlCommand
        Dim pubs As ConnectionStringSettings

        'CONNECTION STRING
        'Load the variable and ID the connectionstring from app.config
        pubs = ConfigurationManager.ConnectionStrings(PWC)
        ProjectCon.ConnectionString = pubs.ConnectionString
        ProjectCon.Open()

        'Create a new sqlcommand; object based on the ProjectConnection object
        Dim cmd As SqlCommand = ProjectCon.CreateCommand

        'Establish the command Type/Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_pps_secretaryname_selectall"

        Reader = cmd.ExecuteReader()

        With Reader
            Do While .Read
                If IsDBNull(Reader.Item(3)) Then
                    LoadSecretaryHash.Add(.Item(0), .Item(2))
                Else
                    LoadSecretaryHash.Add(.Item(0), .Item(2) & ", " & .Item(3))
                End If
            Loop
        End With

    End Function

    Public Function LoadConsultantTypeHash() As Hashtable

        Dim Reader As SqlDataReader
        LoadConsultantTypeHash = New Hashtable
        Dim ProjectCon As New SqlConnection
        Dim ProjectCom As New SqlCommand
        Dim pubs As ConnectionStringSettings

        'CONNECTION STRING
        'Load the variable and ID the connectionstring from app.config
        pubs = ConfigurationManager.ConnectionStrings(PWC)
        ProjectCon.ConnectionString = pubs.ConnectionString
        ProjectCon.Open()

        'Create a new sqlcommand object based on the ProjectConnection object
        Dim cmd As SqlCommand = ProjectCon.CreateCommand

        'Establish the command Type/Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_npc_consultant_selectall"

        Reader = cmd.ExecuteReader()

        With Reader
            Do While .Read
                LoadConsultantTypeHash.Add(.Item(0), .Item(1))
            Loop
        End With

    End Function


    Public Function LoadContractorHash() As Hashtable

        Dim Reader As SqlDataReader
        LoadContractorHash = New Hashtable
        Dim ProjectCon As New SqlConnection
        Dim ProjectCom As New SqlCommand
        Dim pubs As ConnectionStringSettings

        'CONNECTION STRING
        'Load the variable and ID the connectionstring from app.config
        pubs = ConfigurationManager.ConnectionStrings(PWC)
        ProjectCon.ConnectionString = pubs.ConnectionString
        ProjectCon.Open()

        'Create a new sqlcommand object based on the ProjectConnection object
        Dim cmd As SqlCommand = ProjectCon.CreateCommand

        'Establish the command Type/Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ncn_contractor_selectall"

        Reader = cmd.ExecuteReader()

        With Reader
            Do While .Read
                LoadContractorHash.Add(.Item(0), .Item(1))
            Loop
        End With

    End Function


    Public Function LoadProjectTypeHash() As Hashtable

        Dim Reader As SqlDataReader
        LoadProjectTypeHash = New Hashtable
        Dim ProjectCon As New SqlConnection
        Dim ProjectCom As New SqlCommand
        Dim pubs As ConnectionStringSettings

        'CONNECTION STRING
        'Load the variable and ID the connectionstring from app.config
        pubs = ConfigurationManager.ConnectionStrings(PWC)
        ProjectCon.ConnectionString = pubs.ConnectionString
        ProjectCon.Open()

        'Create a new sqlcommand object based on the ProjectConnection object
        Dim cmd As SqlCommand = ProjectCon.CreateCommand

        'Establish the command Type/Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ppt_projecttype_selectall"

        Reader = cmd.ExecuteReader()

        With Reader
            Do While .Read
                LoadProjectTypeHash.Add(.Item(0), .Item(1))
            Loop
        End With

    End Function

    Public Function LoadProjectUserHash() As Hashtable

        Dim Reader As SqlDataReader
        LoadProjectUserHash = New Hashtable
        Dim ProjectCon As New SqlConnection
        Dim ProjectCom As New SqlCommand
        Dim pubs As ConnectionStringSettings

        'CONNECTION STRING
        'Load the variable and ID the connectionstring from app.config
        pubs = ConfigurationManager.ConnectionStrings(PWC)
        ProjectCon.ConnectionString = pubs.ConnectionString
        ProjectCon.Open()

        'Create a new sqlcommand object based on the ProjectConnection object
        Dim cmd As SqlCommand = ProjectCon.CreateCommand

        'Establish the command Type/Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ppu_user_selectall"

        Reader = cmd.ExecuteReader()

        With Reader
            Do While .Read
                If IsDBNull(.Item(2)) Then
                    LoadProjectUserHash.Add(.Item(0), .Item(1))
                Else
                    LoadProjectUserHash.Add(.Item(0), .Item(2) & ", " & .Item(1))   'val = lname, fname
                End If
            Loop
        End With

    End Function

    Public Function LoadProjectNumberHash() As Hashtable

        Dim Reader As SqlDataReader
        LoadProjectNumberHash = New Hashtable
        Dim ProjectCon As New SqlConnection
        Dim ProjectCom As New SqlCommand
        Dim pubs As ConnectionStringSettings

        'CONNECTION STRING
        'Load the variable and ID the connectionstring from app.config
        pubs = ConfigurationManager.ConnectionStrings(PWC)
        ProjectCon.ConnectionString = pubs.ConnectionString
        ProjectCon.Open()

        'Create a new sqlcommand object based on the ProjectConnection object
        Dim cmd As SqlCommand = ProjectCon.CreateCommand

        'Establish the command Type/Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ppm_main_nbr_id"

        Reader = cmd.ExecuteReader()

        With Reader
            Do While .Read
                LoadProjectNumberHash.Add(.Item(0), .Item(1))
            Loop
        End With

    End Function


    Public Function LoadProjectNumber() As SqlDataReader

        Dim Reader As SqlDataReader
        Dim ProjectCon As New SqlConnection
        Dim ProjectCom As New SqlCommand
        Dim pubs As ConnectionStringSettings

        'CONNECTION STRING
        'Load the variable and ID the connectionstring from app.config
        pubs = ConfigurationManager.ConnectionStrings(PWC)
        ProjectCon.ConnectionString = pubs.ConnectionString
        ProjectCon.Open()

        'Create a new sqlcommand object based on the ProjectConnection object
        Dim cmd As SqlCommand = ProjectCon.CreateCommand

        'Establish the command Type/Text
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "usp_ppm_main_nonameid"

        Reader = cmd.ExecuteReader()
        Return Reader

    End Function


    Private disposedValue As Boolean = False    ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class