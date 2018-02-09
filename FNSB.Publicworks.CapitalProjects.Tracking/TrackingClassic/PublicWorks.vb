Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.Sql
Imports System.Data.Common
Imports System.Data.SqlClient

''' <summary>
''' Business Objects is a demo class that queries CSPRojects Project_User_Definition and load into an ArrayList
''' </summary>
''' <remarks></remarks>
Public Class PublicWorks

  Private PublicWorks(47) As Object
  Private PublicWorksNames(47) As String
  Private PublicWorksProjectTables As Collection

  Public Enum Type
    Facilties
    Projects
  End Enum

  'Public Function ThirdPartyQuery() As DataTable
  '  Dim PTQ As New PublicWorksQueries
  '  ThirdPartyQuery = PTQ.AllRecordsThirdParty("usp_ppt_thirdParty_selectall")
  'End Function

  Public Function PublicWorksLoadProjects() As DataTable

        PublicWorksLoadProjects = New DataTable
        PublicWorksLoadProjects.TableName = "Projects"
        PublicWorksLoadProjects = PublicWorksQuery(Type.Projects)
        NameProjectFields()

  End Function

    Public Function CalculateFundBalance(ByVal projectID As Integer, ByRef FundValues As DataTable) As Decimal()

        Dim fundbalanceDec() As Decimal = {0D, 0D, 0D, 0D}
        Dim checkdataview As New DataView
        checkdataview.Table = FundValues
        checkdataview.RowFilter = "ppm_recordid = " & projectID

        If Not checkdataview.Count = 0 Then
            fundbalanceDec(0) = FundValues.Compute("Sum(ppf_budget)", "ppm_recordid = " & projectID)
            fundbalanceDec(1) = FundValues.Compute("Sum(ppf_expenditures)", "ppm_recordid = " & projectID)
            fundbalanceDec(2) = FundValues.Compute("Sum(ppf_encumbrances)", "ppm_recordid = " & projectID)
            fundbalanceDec(3) = fundbalanceDec(0) - (fundbalanceDec(1) + fundbalanceDec(2))    'calculate the balance
        End If

        checkdataview = Nothing
        Return fundbalanceDec

    End Function

  Public Function PublicWorksLoadFunding() As DataTable

    PublicWorksLoadFunding = New DataTable
    PublicWorksLoadFunding.TableName = "Funding"
    PublicWorksLoadFunding = Me.PublicWorksFundingQuery()

  End Function

    'Public Function PublicWorksLoadPhotos() As DataTable

    '  PublicWorksLoadPhotos = New DataTable
    '  PublicWorksLoadPhotos.TableName = "Photos"
    '  PublicWorksLoadPhotos = Me.PublicWorksPhotoQuery()

    '  End Function



    Public Function PublicWorksPhotosUpdate(ByVal PhotosDataTable As DataTable) As Integer

        Dim PTQ As New PublicWorksQueries
        Dim i As Integer

        i = PTQ.PhotosUpdate(PhotosDataTable)

    End Function


    Public Function PublicWorksFundingDelete(ByVal FundingDataTable As DataTable) As Integer

        Try
            Dim PTQ As New PublicWorksQueries
            Dim i As Integer
            i = PTQ.FundingDelete(FundingDataTable)
        Catch ex As Exception

        End Try

    End Function

    Public Function PublicWorksFundingUpdate(ByVal FundingDataTable As DataTable) As Integer

        Try
            Dim PTQ As New PublicWorksQueries
            Return PTQ.FundingUpdate(FundingDataTable)
        Catch ex As Exception

        End Try

    End Function

    Public Function PublicWorksFundingDataRowUpdate(ByVal FundingDataRows() As DataRow) As Integer

        Try
            Dim PTQ As New PublicWorksQueries
            Dim i As Integer
            i = PTQ.FundingRowsUpdate(FundingDataRows)
        Catch ex As Exception

        End Try

    End Function

    Public Function FundingRowsDelete(ByVal FundDeleteRecordID As Integer) As Integer

        Try
            Dim PTQ As New PublicWorksQueries
            Dim i As Integer
            i = PTQ.FundingRowsDelete(FundDeleteRecordID)
        Catch ex As Exception

        End Try

    End Function



    Public Function PublicWorksUpdateEntity(ByVal EntityDataTable As DataTable) As Integer

        Try

            Dim PTQ As New PublicWorksQueries
            PTQ.EntityUpdate(EntityDataTable)

        Catch ex As Exception

        End Try

    End Function

    Public Function PublicWorksDeleteProjects(ByVal WorksDataRow() As DataRow) As Integer

        Dim PTQ As New PublicWorksQueries
        Dim i As Integer

        i = PTQ.ProjectsDelete(WorksDataRow)

    End Function

    Public Function PublicWorksUpdateProjects(ByVal WorksDataTable As DataTable) As Integer

        Dim PTQ As New PublicWorksQueries
        Dim i As Integer

        i = PTQ.ProjectsUpdate(WorksDataTable)

    End Function
    Public Function PublicWorksUpdateProjectRow(ByVal projectDataRow As DataRow) As Integer

        Try
            Dim PTQ As New PublicWorksQueries
            Dim i As Integer
            i = PTQ.ProjectsUpdate(projectDataRow)
        Catch ex As Exception

        End Try

    End Function


    Public Function PublicWorksProjectsMiniView() As DataTable

        Dim PTQ As New PublicWorksQueries
        PublicWorksProjectsMiniView = PTQ.ProjectsMiniView("usp_ppm_main_selectallLite")

    End Function




    'The Overloaded PublicWorksQuery can determines the PublicWorks type and then takes
    ' KeyVal as the other variable
    Public Overloads Function PublicWorksQuery(ByVal KeyVal As Type) As DataTable

        Dim PTQ As New PublicWorksQueries

        Select Case KeyVal
            Case Type.Facilties
                MessageBox.Show("@Facilties")
                PublicWorksQuery = PTQ.ProjectsDataTable(Type.Facilties, "PFM_Main_SelectAll")
            Case Type.Projects
                PublicWorksQuery = PTQ.ProjectsDataTable(Type.Projects, "Publicworks.usp_ppm_main_selectall")
        End Select

    End Function


    Public Function PublicWorksSecretaryHash() As Hashtable

        Dim PTQ As New PublicWorksQueries
        PublicWorksSecretaryHash = PTQ.LoadSecretaryHash()

    End Function

    Public Function PublicWorksConsultantHash() As Hashtable

        Dim PTQ As New PublicWorksQueries
        PublicWorksConsultantHash = PTQ.LoadConsultantTypeHash()

    End Function

    Public Function PublicWorksContractorHash() As Hashtable

        Dim PTQ As New PublicWorksQueries
        PublicWorksContractorHash = PTQ.LoadContractorHash()

    End Function

    Public Function PublicWorksProjectTypeHash() As Hashtable

        Dim PTQ As New PublicWorksQueries
        PublicWorksProjectTypeHash = PTQ.LoadProjectTypeHash()

    End Function

    Public Function PublicWorksProjectUserHash() As Hashtable

        Dim PTQ As New PublicWorksQueries
        PublicWorksProjectUserHash = PTQ.LoadProjectUserHash()

    End Function


    Public Function PublicWorksProjectNumberHash() As Hashtable

        Dim PTQ As New PublicWorksQueries
        PublicWorksProjectNumberHash = PTQ.LoadProjectNumberHash()

    End Function

    'Publicworks DataTables

    Public Function PublicWorksUsers() As DataTable

        Dim PTQ As New PublicWorksQueries
        PublicWorksUsers = PTQ.LoadProjectUsers("usp_ppu_user_selectall")

    End Function



    Public Function PublicWorksProjectManagerTable() As DataTable

        Dim PTQ As New PublicWorksQueries
        Return PTQ.ProjectManagerTable()

    End Function

    Public Function PublicWorksProjectArchitechTable() As DataTable

        Dim PTQ As New PublicWorksQueries
        Return PTQ.ProjectArchitectTable()

    End Function

    Public Function PublicWorksProjectSecretaryTable() As DataTable

        Dim PTQ As New PublicWorksQueries
        Return PTQ.ProjectSecretaryTable()

    End Function

    Public Function PublicWorksProjectTypesTable() As DataTable

        Dim PTQ As New PublicWorksQueries
        Return PTQ.ProjectTypeTable()

    End Function

    Public Function PublicWorksProjectUsersTable() As DataTable

        Dim PTQ As New PublicWorksQueries
        Return PTQ.ProjectUserTable()

    End Function

    Private Function PublicWorksFundingQuery() As DataTable

        Dim PTQ As New PublicWorksQueries
        PublicWorksFundingQuery = PTQ.ProjectFunding("Publicworks.usp_ppi_ifas_selectall")
    End Function

    Private Function PublicWorksPhotoQuery() As DataTable

        Dim PTQ As New PublicWorksQueries
        PublicWorksPhotoQuery = PTQ.ProjectPhoto("usp_ppp_photo_selectall")

    End Function

    Public Function PublicWorksProjectsReader() As SqlDataReader

        Dim PTQ As New PublicWorksQueries
        Dim Reader As SqlDataReader = PTQ.LoadProjectNumber
        Return Reader

    End Function

    'Public Function PublicWorksMgrConsultDataSet() As DataSet

    'End Function

    Public Sub NameProjectFields()

        With PublicWorksNames
            .SetValue("Project Number", 1)
            .SetValue("Project Name", 2)
            .SetValue("Status", 6)
            .SetValue("Construction Complete", 19)
            .SetValue("Bid Opening", 26)
            .SetValue("Design Complete", 30)
            .SetValue("NTP Date", 33)
            .SetValue("Substantial Completion", 34)
            .SetValue("Correction Period Ends", 36)
            .SetValue("Project Manager", 41)
            .SetValue("Architect/Engineer", 44)
        End With

    End Sub

    Public ReadOnly Property PublicWorksProjectsFieldNames() As Array
        Get
            Return Me.PublicWorksNames
        End Get
    End Property
    Public Property ProjectRecordID() As Object
        Get
            Return PublicWorks(0)
        End Get
        Set(ByVal value As Object)
            PublicWorks(0) = value
        End Set
    End Property


    Public Property ProjectStatus() As Object
        Get
            Return PublicWorks(1)
        End Get
        Set(ByVal value As Object)
            PublicWorks(1) = value
        End Set
    End Property

    Public Property ProjectNumberName() As String
        Get
            Return PublicWorksNames(2)
        End Get
        Set(ByVal value As String)
            PublicWorksNames(2) = value
        End Set
    End Property

    Public Property ProjectNumber() As Object
        Get
            Return PublicWorks(2)
        End Get
        Set(ByVal value As Object)
            PublicWorks(2) = value
        End Set
    End Property

    Public Property ProjectPhase() As Object
        Get
            Return PublicWorks(3)
        End Get
        Set(ByVal value As Object)
            PublicWorks(3) = value
        End Set
    End Property


    Public Property ProjectName() As Object
        Get
            Return PublicWorks(4)
        End Get
        Set(ByVal value As Object)
            PublicWorks(4) = value
        End Set
    End Property


    Public Property ProjectActiveDate() As Object
        Get
            Return PublicWorks(5)
        End Get
        Set(ByVal value As Object)
            PublicWorks(5) = value
        End Set
    End Property

    Public Property ProjectInactiveDate() As Object
        Get
            Return PublicWorks(6)
        End Get
        Set(ByVal value As Object)
            PublicWorks(6) = value
        End Set
    End Property

    Public Property PercentageDesignComplete() As Object
        Get
            Return PublicWorks(7)
        End Get
        Set(ByVal value As Object)
            PublicWorks(7) = value
        End Set
    End Property

    Public Property ProjectStatusDesc() As Object
        Get
            Return PublicWorks(8)
        End Get
        Set(ByVal value As Object)
            PublicWorks(8) = value
        End Set
    End Property


    Public Property ProjectScopeDesc() As Object
        Get
            Return PublicWorks(9)
        End Get
        Set(ByVal value As Object)
            PublicWorks(9) = value
        End Set
    End Property

    Public Property ProjectMSAUpdateFlag() As Object
        Get
            Return PublicWorks(10)
        End Get
        Set(ByVal value As Object)
            PublicWorks(10) = value
        End Set
    End Property

    Public Property ProjectBudget() As Object
        Get
            Return PublicWorks(11)
        End Get
        Set(ByVal value As Object)
            PublicWorks(11) = value
        End Set
    End Property

    Public Property ProjectAvailableBalance() As Object
        Get
            Return PublicWorks(12)
        End Get
        Set(ByVal value As Object)
            PublicWorks(12) = value
        End Set
    End Property

    Public Property ProjectEncumbrances() As Object
        Get
            Return PublicWorks(13)
        End Get
        Set(ByVal value As Object)
            PublicWorks(13) = value
        End Set
    End Property

    Public Property ProjectLTDExpenditures() As Object
        Get
            Return PublicWorks(14)
        End Get
        Set(ByVal value As Object)
            PublicWorks(14) = value
        End Set
    End Property

    Public Property ProjectConsultantFee() As Object
        Get
            Return PublicWorks(15)
        End Get
        Set(ByVal value As Object)
            PublicWorks(15) = value
        End Set
    End Property

    Public Property ProjectContractAmount() As Object
        Get
            Return PublicWorks(16)
        End Get
        Set(ByVal value As Object)
            PublicWorks(16) = value
        End Set
    End Property

    Public Property ProjectContractAmendments() As Object
        Get
            Return PublicWorks(17)
        End Get
        Set(ByVal value As Object)
            PublicWorks(17) = value
        End Set
    End Property

    Public Property ProjectChangeOrders() As Object
        Get
            Return PublicWorks(18)
        End Get
        Set(ByVal value As Object)
            PublicWorks(18) = value
        End Set
    End Property

    Public Property ProjectPercentConstComplete() As Object
        Get
            Return PublicWorks(19)
        End Get
        Set(ByVal value As Object)
            PublicWorks(19) = value
        End Set
    End Property

    Public Property ProjectIFBRFQ() As Object
        Get
            Return PublicWorks(20)
        End Get
        Set(ByVal value As Object)
            PublicWorks(20) = value
        End Set
    End Property

    Public Property ProjectUserLetter() As Object
        Get
            Return PublicWorks(21)
        End Get
        Set(ByVal value As Object)
            PublicWorks(21) = value
        End Set
    End Property

    Public Property ProjectRFP() As Object
        Get
            Return PublicWorks(22)
        End Get
        Set(ByVal value As Object)
            PublicWorks(22) = value
        End Set
    End Property

    Public Property ProjectScope() As Object
        Get
            Return PublicWorks(23)
        End Get
        Set(ByVal value As Object)
            PublicWorks(22) = value
        End Set
    End Property

    Public Property ProjectAdvertisedForBid() As Object
        Get
            Return PublicWorks(24)
        End Get
        Set(ByVal value As Object)
            PublicWorks(24) = value
        End Set
    End Property

    Public Property ProjectOriginalBidDate() As Object
        Get
            Return PublicWorks(25)
        End Get
        Set(ByVal value As Object)
            PublicWorks(25) = value
        End Set
    End Property

    Public Property ProjectBidOpening() As Object
        Get
            Return PublicWorks(26)
        End Get
        Set(ByVal value As Object)
            PublicWorks(26) = value
        End Set
    End Property

    Public Property ProjectGeneralServicesReview() As Object
        Get
            Return PublicWorks(27)
        End Get
        Set(ByVal value As Object)
            PublicWorks(27) = value
        End Set
    End Property

    Public Property ProjectConsultantAward() As Object
        Get
            Return PublicWorks(28)
        End Get
        Set(ByVal value As Object)
            PublicWorks(28) = value
        End Set
    End Property

    Public Property ProjectConstBidDate() As Object
        Get
            Return PublicWorks(29)
        End Get
        Set(ByVal value As Object)
            PublicWorks(29) = value
        End Set
    End Property

    Public Property ProjectDesignComplete() As Object
        Get
            Return PublicWorks(30)
        End Get
        Set(ByVal value As Object)
            PublicWorks(30) = value
        End Set
    End Property

    Public Property ProjectAgendaSetDate() As Object
        Get
            Return PublicWorks(31)
        End Get
        Set(ByVal value As Object)
            PublicWorks(31) = value
        End Set
    End Property

    Public Property ProjectAssemblyApprovalDate() As Object
        Get
            Return PublicWorks(32)
        End Get
        Set(ByVal value As Object)
            PublicWorks(32) = value
        End Set
    End Property

    Public Property ProjectNTP() As Object
        Get
            Return PublicWorks(33)
        End Get
        Set(ByVal value As Object)
            PublicWorks(33) = value
        End Set
    End Property

    Public Property ProjectSubstantialCompletion() As Object
        Get
            Return PublicWorks(34)
        End Get
        Set(ByVal value As Object)
            PublicWorks(34) = value
        End Set
    End Property

    Public Property ProjectFinalInspection() As Object
        Get
            Return PublicWorks(35)
        End Get
        Set(ByVal value As Object)
            PublicWorks(35) = value
        End Set
    End Property

    Public Property ProjectWarrentyPeriodEnds() As Object
        Get
            Return PublicWorks(36)
        End Get
        Set(ByVal value As Object)
            PublicWorks(36) = value
        End Set
    End Property

    Public Property ProjectClosedDate() As Object
        Get
            Return PublicWorks(37)
        End Get
        Set(ByVal value As Object)
            PublicWorks(37) = value
        End Set
    End Property

    Public Property ProjectSecretaryID() As Object
        Get
            Return PublicWorks(38)
        End Get
        Set(ByVal value As Object)
            PublicWorks(38) = value
        End Set
    End Property

    Public Property ProjectUserID() As Object
        Get
            Return PublicWorks(39)
        End Get
        Set(ByVal value As Object)
            PublicWorks(39) = value
        End Set
    End Property

    Public Property ProjectTypeID() As Object
        Get
            Return PublicWorks(40)
        End Get
        Set(ByVal value As Object)
            PublicWorks(40) = value
        End Set
    End Property

    Public Property ProjectManagerID() As Object
        Get
            Return PublicWorks(41)
        End Get
        Set(ByVal value As Object)
            PublicWorks(41) = value
        End Set
    End Property

    Public Property ProjectAsstManagerID() As Object
        Get
            Return PublicWorks(42)
        End Get
        Set(ByVal value As Object)
            PublicWorks(42) = value
        End Set
    End Property

    Public Property ProjectConsultantID() As Object
        Get
            Return PublicWorks(43)
        End Get
        Set(ByVal value As Object)
            PublicWorks(43) = value
        End Set
    End Property

    Public Property ProjectArcitectEngID() As Object
        Get
            Return PublicWorks(44)
        End Get
        Set(ByVal value As Object)
            PublicWorks(44) = value
        End Set
    End Property

    Public Property ProjectContractorID() As Object
        Get
            Return PublicWorks(45)
        End Get
        Set(ByVal value As Object)
            PublicWorks(45) = value
        End Set
    End Property

    Public Property ProjectNOUID() As Object
        Get
            Return PublicWorks(46)
        End Get
        Set(ByVal value As Object)
            PublicWorks(46) = value
        End Set
    End Property

    Public Property ProjectFacilityMaintenanceID() As Object
        Get
            Return PublicWorks(47)
        End Get
        Set(ByVal value As Object)
            PublicWorks(47) = value
        End Set
    End Property


End Class
