
Option Explicit On

Imports System.Data
Imports System.Collections.Generic
Imports System.Deployment.Application
Imports FNSB_Facilities_Projects.My.Resources
Imports GrapeCity.ActiveReports
Imports FNSB.Publicworks.Projects.DataLayer.Model
Imports FNSB.Publicworks.Projects.DataLayer.Service
Imports FNSB.Publicworks.Projects.DataLayer
Imports FNSB.Publicworks.Projects.Reports.UI
Imports FNSB.Publicworks.Projects.Reporting.Reports
Imports FNSB.Publicworks.Projects.Reporting.Reports.UI


Public Class FrmProjectTrack
    Inherits Windows.Forms.Form

    Private _fundgridColCollection As DataGridViewColumnCollection
    Private _projgridColCollection As DataGridViewColumnCollection

    Private ReadOnly _projectDataset As New DataSet
    Private _projectsDatatable As DataTable
    'Primary Projects Data Table
    Private _fundingDatatable As DataTable
    'Primary Projects Funding Table
    Private _fundingAggregateDataTable As DataTable
    'Funding Summary Details
    Private ReadOnly _projectBinding As New BindingSource()
    Private ReadOnly _fundBinding As New BindingSource()

    Private _projectRowStyle As DataGridViewCellStyle

    'when users drag and drop funds to the parent tracking form
    Private _modifiedList As List(Of Integer)
    Private _addedList As List(Of Integer)
    Private _fundsList As List(Of Integer)

    Private _statusChanged As Boolean
    Private _initialLoad As Boolean

    'Report Handling Events
    Private fundmanageForm As PublicWorksFunding
    Private miProjectID As Integer
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents buildStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents builsStripLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents activeDatePicker As System.Windows.Forms.MaskedTextBox
    Friend WithEvents inactiveDatePicker As System.Windows.Forms.MaskedTextBox
    Friend WithEvents projectArchitectDetailReportLink As System.Windows.Forms.LinkLabel
    Friend WithEvents managerDetailReportLink As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel10 As System.Windows.Forms.LinkLabel
    Friend WithEvents estimatedBidLink As System.Windows.Forms.LinkLabel
    Friend WithEvents substantialCompletionLink As System.Windows.Forms.LinkLabel
    Friend WithEvents capitalProjectsReport As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSecretaryDetail As System.Windows.Forms.LinkLabel
    Friend WithEvents chkProjectComplete As System.Windows.Forms.CheckBox
    'Primary ProjectID manager Variable

    Enum meFundMode
        'Used in conjuction with miFundingMode to maintain the state of funding mode
        All
        Project
        Unallocated
        Import
        Group
        Allocated
    End Enum

    Private Enum ViewState
        Active = 0
        Inactive = 1
        All = 2
    End Enum

    Private _projectsViewState As Integer


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cboProjectType As System.Windows.Forms.ComboBox
    Friend WithEvents lnkEditType As System.Windows.Forms.LinkLabel
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents activestatusCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblActiveDate As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents ManagerLink As System.Windows.Forms.LinkLabel
    Friend WithEvents secretaryEdit As System.Windows.Forms.LinkLabel
    Friend WithEvents ArcLink As System.Windows.Forms.LinkLabel
    Friend WithEvents UserEditLink As System.Windows.Forms.LinkLabel
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSecretary As System.Windows.Forms.ComboBox
    Friend WithEvents cboArchitect As System.Windows.Forms.ComboBox
    Friend WithEvents cboProjectManager As System.Windows.Forms.ComboBox
    Friend WithEvents cboProjectUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cgdAgg As System.Windows.Forms.DataGridView
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents tabReports As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents maskConsultAward As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskConsultScopeApproval As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskConsultRFPDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskConsultIfbRfq As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskConsultDesignCompleted As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractClosedDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractConstNtp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractGenServices As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractWarrantyPeriodEnds As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractConstBidAward As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractBidOpening As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractFinalPayment As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractAssbApproval As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractAdvertiseBid As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractSubstantialCompletion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractAgendaSetting As System.Windows.Forms.MaskedTextBox
    Friend WithEvents maskContractOriginalBid As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents managerProjectsReport As System.Windows.Forms.LinkLabel
    Friend WithEvents secretaryProjectsReport As System.Windows.Forms.LinkLabel
    Friend WithEvents orgkeyProjectReport As System.Windows.Forms.LinkLabel
    Friend WithEvents warrentyReport As System.Windows.Forms.LinkLabel
    Friend WithEvents closedProjectsLink As System.Windows.Forms.LinkLabel
    Friend WithEvents projectReportLink As System.Windows.Forms.LinkLabel
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents projectsNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents projectsaveButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents prodeleteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents addprojectButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents undoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsbSelectStatus As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents projectfilterTextbox As System.Windows.Forms.ToolStripTextBox
    Private WithEvents spellControl As C1.Win.C1SpellChecker.C1SpellChecker
    Friend WithEvents tapContractor As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblContractWarPeriod As System.Windows.Forms.Label
    Friend WithEvents lblContractAmount As System.Windows.Forms.Label
    Friend WithEvents txtContractChangeOrders As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtContractAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtContractCO As System.Windows.Forms.TextBox
    Friend WithEvents txtConstComplete As System.Windows.Forms.TextBox
    Friend WithEvents lnkEditContractor As System.Windows.Forms.LinkLabel
    Friend WithEvents cboContractor As System.Windows.Forms.ComboBox
    Friend WithEvents tapConsultant As System.Windows.Forms.TabPage
    Friend WithEvents lblConsultant As System.Windows.Forms.Label
    Friend WithEvents lblScope As System.Windows.Forms.Label
    Friend WithEvents lblConAward As System.Windows.Forms.Label
    Friend WithEvents lblDesignComp As System.Windows.Forms.Label
    Friend WithEvents lblDesignComplete As System.Windows.Forms.Label
    Friend WithEvents lblIFB As System.Windows.Forms.Label
    Friend WithEvents lblConFee As System.Windows.Forms.Label
    Friend WithEvents lblConAmend As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboRFPDiscipline As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblConsultRFP As System.Windows.Forms.Label
    Friend WithEvents txtConsultDesignCompPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtConsultFee As System.Windows.Forms.TextBox
    Friend WithEvents txtConsultContractAmend As System.Windows.Forms.TextBox
    Friend WithEvents txtRFPNo As System.Windows.Forms.TextBox
    Friend WithEvents lnkEditConsultant As System.Windows.Forms.LinkLabel
    Friend WithEvents cboConsultant As System.Windows.Forms.ComboBox
    Friend WithEvents tapScope As System.Windows.Forms.TabPage
    Friend WithEvents txtProjectScope As System.Windows.Forms.TextBox
    Friend WithEvents scopeSpell As System.Windows.Forms.LinkLabel
    Friend WithEvents tapProject As System.Windows.Forms.TabPage
    Friend WithEvents lblProjectTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblProjectNo As System.Windows.Forms.Label
    Friend WithEvents statusSpell As System.Windows.Forms.LinkLabel
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectStatusDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectNumber As System.Windows.Forms.TextBox
    Friend WithEvents fundmanageLink As System.Windows.Forms.LinkLabel
    Friend WithEvents tabSupport As System.Windows.Forms.TabControl
    Friend WithEvents cgdFund As System.Windows.Forms.DataGridView
    Private ProjectScope As Byte
    Friend WithEvents cgdProject As System.Windows.Forms.DataGridView
    Friend WithEvents tspTopMenu As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ofdWorksPhoto As System.Windows.Forms.OpenFileDialog
    Private WithEvents ofdIfasUpload As System.Windows.Forms.OpenFileDialog
    Private WithEvents imlFunding As System.Windows.Forms.ImageList
    Private WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ActiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents InactiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents AllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tolSaveProject As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tolDeleteProject As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents CurrentFiscalYearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Private WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel8 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel9 As System.Windows.Forms.LinkLabel
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label



    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProjectTrack))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel()
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InactiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrentFiscalYearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tolSaveProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.tolDeleteProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofdIfasUpload = New System.Windows.Forms.OpenFileDialog()
        Me.imlFunding = New System.Windows.Forms.ImageList(Me.components)
        Me.ofdWorksPhoto = New System.Windows.Forms.OpenFileDialog()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cgdProject = New System.Windows.Forms.DataGridView()
        Me.tapContractor = New System.Windows.Forms.TabPage()
        Me.maskContractClosedDate = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractConstNtp = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractGenServices = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractWarrantyPeriodEnds = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractConstBidAward = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractBidOpening = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractFinalPayment = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractAssbApproval = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractAdvertiseBid = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractSubstantialCompletion = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractAgendaSetting = New System.Windows.Forms.MaskedTextBox()
        Me.maskContractOriginalBid = New System.Windows.Forms.MaskedTextBox()
        Me.cboContractor = New System.Windows.Forms.ComboBox()
        Me.lnkEditContractor = New System.Windows.Forms.LinkLabel()
        Me.txtConstComplete = New System.Windows.Forms.TextBox()
        Me.txtContractCO = New System.Windows.Forms.TextBox()
        Me.txtContractAmount = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtContractChangeOrders = New System.Windows.Forms.Label()
        Me.lblContractAmount = New System.Windows.Forms.Label()
        Me.lblContractWarPeriod = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tapConsultant = New System.Windows.Forms.TabPage()
        Me.maskConsultIfbRfq = New System.Windows.Forms.MaskedTextBox()
        Me.maskConsultDesignCompleted = New System.Windows.Forms.MaskedTextBox()
        Me.maskConsultAward = New System.Windows.Forms.MaskedTextBox()
        Me.maskConsultRFPDate = New System.Windows.Forms.MaskedTextBox()
        Me.maskConsultScopeApproval = New System.Windows.Forms.MaskedTextBox()
        Me.cboConsultant = New System.Windows.Forms.ComboBox()
        Me.lnkEditConsultant = New System.Windows.Forms.LinkLabel()
        Me.txtRFPNo = New System.Windows.Forms.TextBox()
        Me.txtConsultContractAmend = New System.Windows.Forms.TextBox()
        Me.txtConsultFee = New System.Windows.Forms.TextBox()
        Me.txtConsultDesignCompPercent = New System.Windows.Forms.TextBox()
        Me.lblConsultRFP = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboRFPDiscipline = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblConAmend = New System.Windows.Forms.Label()
        Me.lblConFee = New System.Windows.Forms.Label()
        Me.lblIFB = New System.Windows.Forms.Label()
        Me.lblDesignComplete = New System.Windows.Forms.Label()
        Me.lblDesignComp = New System.Windows.Forms.Label()
        Me.lblConAward = New System.Windows.Forms.Label()
        Me.lblScope = New System.Windows.Forms.Label()
        Me.lblConsultant = New System.Windows.Forms.Label()
        Me.tapScope = New System.Windows.Forms.TabPage()
        Me.scopeSpell = New System.Windows.Forms.LinkLabel()
        Me.txtProjectScope = New System.Windows.Forms.TextBox()
        Me.tapProject = New System.Windows.Forms.TabPage()
        Me.inactiveDatePicker = New System.Windows.Forms.MaskedTextBox()
        Me.activeDatePicker = New System.Windows.Forms.MaskedTextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cgdAgg = New System.Windows.Forms.DataGridView()
        Me.ManagerLink = New System.Windows.Forms.LinkLabel()
        Me.secretaryEdit = New System.Windows.Forms.LinkLabel()
        Me.ArcLink = New System.Windows.Forms.LinkLabel()
        Me.UserEditLink = New System.Windows.Forms.LinkLabel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSecretary = New System.Windows.Forms.ComboBox()
        Me.cboArchitect = New System.Windows.Forms.ComboBox()
        Me.cboProjectManager = New System.Windows.Forms.ComboBox()
        Me.cboProjectUser = New System.Windows.Forms.ComboBox()
        Me.cboProjectType = New System.Windows.Forms.ComboBox()
        Me.lnkEditType = New System.Windows.Forms.LinkLabel()
        Me.lblType = New System.Windows.Forms.Label()
        Me.cgdFund = New System.Windows.Forms.DataGridView()
        Me.chkProjectComplete = New System.Windows.Forms.CheckBox()
        Me.activestatusCheckbox = New System.Windows.Forms.CheckBox()
        Me.fundmanageLink = New System.Windows.Forms.LinkLabel()
        Me.txtProjectNumber = New System.Windows.Forms.TextBox()
        Me.txtProjectStatusDesc = New System.Windows.Forms.TextBox()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblActiveDate = New System.Windows.Forms.Label()
        Me.statusSpell = New System.Windows.Forms.LinkLabel()
        Me.lblProjectNo = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblProjectTitle = New System.Windows.Forms.Label()
        Me.tabSupport = New System.Windows.Forms.TabControl()
        Me.tabReports = New System.Windows.Forms.TabPage()
        Me.lnkSecretaryDetail = New System.Windows.Forms.LinkLabel()
        Me.projectArchitectDetailReportLink = New System.Windows.Forms.LinkLabel()
        Me.managerProjectsReport = New System.Windows.Forms.LinkLabel()
        Me.managerDetailReportLink = New System.Windows.Forms.LinkLabel()
        Me.secretaryProjectsReport = New System.Windows.Forms.LinkLabel()
        Me.capitalProjectsReport = New System.Windows.Forms.LinkLabel()
        Me.orgkeyProjectReport = New System.Windows.Forms.LinkLabel()
        Me.estimatedBidLink = New System.Windows.Forms.LinkLabel()
        Me.substantialCompletionLink = New System.Windows.Forms.LinkLabel()
        Me.warrentyReport = New System.Windows.Forms.LinkLabel()
        Me.closedProjectsLink = New System.Windows.Forms.LinkLabel()
        Me.projectReportLink = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.spellControl = New C1.Win.C1SpellChecker.C1SpellChecker(Me.components)
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.projectsNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.addprojectButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.projectsaveButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.undoButton = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.prodeleteButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.tsbSelectStatus = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.projectfilterTextbox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.builsStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.buildStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel()
        CType(Me.cgdProject,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tapContractor.SuspendLayout
        Me.tapConsultant.SuspendLayout
        Me.tapScope.SuspendLayout
        Me.tapProject.SuspendLayout
        CType(Me.cgdAgg,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cgdFund,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabSupport.SuspendLayout
        Me.tabReports.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.spellControl,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.projectsNavigator,System.ComponentModel.ISupportInitialize).BeginInit
        Me.projectsNavigator.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.statusStrip.SuspendLayout
        Me.SuspendLayout
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(308, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Consultant RFP"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(493, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 21)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Information"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Label18
        '
        Me.Label18.AutoSize = true
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label18.Location = New System.Drawing.Point(283, 163)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(141, 15)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Consultant Amendments"
        '
        'Label19
        '
        Me.Label19.AutoSize = true
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label19.Location = New System.Drawing.Point(323, 139)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 15)
        Me.Label19.TabIndex = 34
        Me.Label19.Text = "Consultant Fee"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox2.Location = New System.Drawing.Point(427, 160)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(128, 21)
        Me.TextBox2.TabIndex = 33
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox3.Location = New System.Drawing.Point(427, 136)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(128, 21)
        Me.TextBox3.TabIndex = 32
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox4.Location = New System.Drawing.Point(122, 139)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(104, 21)
        Me.TextBox4.TabIndex = 31
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = true
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label20.Location = New System.Drawing.Point(4, 146)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 15)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "IFB/RFQ:"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox5.Location = New System.Drawing.Point(426, 61)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(104, 21)
        Me.TextBox5.TabIndex = 28
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = true
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label21.Location = New System.Drawing.Point(4, 115)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(109, 15)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "Design Completed"
        '
        'Label22
        '
        Me.Label22.AutoSize = true
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label22.Location = New System.Drawing.Point(4, 91)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(116, 15)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "Design % Complete"
        '
        'Label23
        '
        Me.Label23.AutoSize = true
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label23.Location = New System.Drawing.Point(4, 67)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(116, 15)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "Consultant Awarded"
        '
        'Label24
        '
        Me.Label24.AutoSize = true
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label24.Location = New System.Drawing.Point(4, 43)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(92, 15)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Scope Approval"
        '
        'Label25
        '
        Me.Label25.AutoSize = true
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 18)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(106, 15)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "Project Consultant"
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox6.Location = New System.Drawing.Point(122, 112)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(104, 21)
        Me.TextBox6.TabIndex = 21
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox7.Location = New System.Drawing.Point(122, 88)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(104, 21)
        Me.TextBox7.TabIndex = 20
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox8
        '
        Me.TextBox8.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox8.Location = New System.Drawing.Point(122, 64)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(104, 21)
        Me.TextBox8.TabIndex = 19
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox9.Location = New System.Drawing.Point(122, 40)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(104, 21)
        Me.TextBox9.TabIndex = 18
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(150, 150)
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 256
        Me.Label2.Text = "Last Inactive Date"
        '
        'Label28
        '
        Me.Label28.AutoSize = true
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label28.Location = New System.Drawing.Point(26, 88)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(93, 15)
        Me.Label28.TabIndex = 255
        Me.Label28.Text = "Last Active Date"
        '
        'Label29
        '
        Me.Label29.AutoSize = true
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label29.Location = New System.Drawing.Point(26, 63)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 15)
        Me.Label29.TabIndex = 149
        Me.Label29.Text = "Project Number"
        '
        'Label31
        '
        Me.Label31.AutoSize = true
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label31.Location = New System.Drawing.Point(27, 36)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(82, 15)
        Me.Label31.TabIndex = 134
        Me.Label31.Text = "Project Name"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(655, 36)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(156, 20)
        Me.TextBox1.TabIndex = 306
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(655, 62)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(156, 20)
        Me.TextBox12.TabIndex = 305
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(655, 87)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(156, 20)
        Me.TextBox13.TabIndex = 304
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(655, 113)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(156, 20)
        Me.TextBox14.TabIndex = 303
        '
        'Label32
        '
        Me.Label32.AutoSize = true
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 10!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label32.Location = New System.Drawing.Point(13, 8)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(197, 17)
        Me.Label32.TabIndex = 302
        Me.Label32.Text = "Public Works Project Tracking"
        '
        'Label33
        '
        Me.Label33.AutoSize = true
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label33.Location = New System.Drawing.Point(25, 138)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(74, 15)
        Me.Label33.TabIndex = 300
        Me.Label33.Text = "Project Type"
        '
        'TextBox15
        '
        Me.TextBox15.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox15.Location = New System.Drawing.Point(137, 111)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(79, 22)
        Me.TextBox15.TabIndex = 258
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox16
        '
        Me.TextBox16.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox16.Location = New System.Drawing.Point(137, 85)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(79, 22)
        Me.TextBox16.TabIndex = 257
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = true
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label34.Location = New System.Drawing.Point(221, 63)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(42, 15)
        Me.Label34.TabIndex = 194
        Me.Label34.Text = "Phase"
        '
        'TextBox17
        '
        Me.TextBox17.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox17.Location = New System.Drawing.Point(269, 60)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(32, 22)
        Me.TextBox17.TabIndex = 193
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = true
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(67, 258)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(64, 13)
        Me.LinkLabel1.TabIndex = 171
        Me.LinkLabel1.TabStop = true
        Me.LinkLabel1.Text = "&Spell Check"
        '
        'CheckBox1
        '
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(334, 61)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 20)
        Me.CheckBox1.TabIndex = 169
        Me.CheckBox1.Text = "Active"
        '
        'TextBox18
        '
        Me.TextBox18.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox18.Location = New System.Drawing.Point(137, 60)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(79, 22)
        Me.TextBox18.TabIndex = 155
        '
        'Label35
        '
        Me.Label35.AutoSize = true
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label35.Location = New System.Drawing.Point(23, 167)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(106, 15)
        Me.Label35.TabIndex = 136
        Me.Label35.Text = "Status Description"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox19
        '
        Me.TextBox19.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox19.Location = New System.Drawing.Point(137, 167)
        Me.TextBox19.Multiline = true
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox19.Size = New System.Drawing.Size(674, 103)
        Me.TextBox19.TabIndex = 135
        '
        'TextBox20
        '
        Me.TextBox20.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox20.Location = New System.Drawing.Point(137, 34)
        Me.TextBox20.MaxLength = 50
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(326, 22)
        Me.TextBox20.TabIndex = 133
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ExportToolStripMenuItem.Text = "Export Project"
        '
        'ActiveToolStripMenuItem
        '
        Me.ActiveToolStripMenuItem.Name = "ActiveToolStripMenuItem"
        Me.ActiveToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ActiveToolStripMenuItem.Text = "Active"
        '
        'InactiveToolStripMenuItem
        '
        Me.InactiveToolStripMenuItem.Name = "InactiveToolStripMenuItem"
        Me.InactiveToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.InactiveToolStripMenuItem.Text = "Inactive"
        '
        'AllToolStripMenuItem
        '
        Me.AllToolStripMenuItem.Name = "AllToolStripMenuItem"
        Me.AllToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AllToolStripMenuItem.Text = "All"
        '
        'CurrentFiscalYearToolStripMenuItem
        '
        Me.CurrentFiscalYearToolStripMenuItem.Name = "CurrentFiscalYearToolStripMenuItem"
        Me.CurrentFiscalYearToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.CurrentFiscalYearToolStripMenuItem.Text = "Current Fiscal Year"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(35, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'tolSaveProject
        '
        Me.tolSaveProject.Name = "tolSaveProject"
        Me.tolSaveProject.Size = New System.Drawing.Size(165, 22)
        Me.tolSaveProject.Text = "Save Project..."
        '
        'tolDeleteProject
        '
        Me.tolDeleteProject.Name = "tolDeleteProject"
        Me.tolDeleteProject.Size = New System.Drawing.Size(165, 22)
        Me.tolDeleteProject.Text = "Delete Project..."
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem6.Text = "Edit"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11})
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(58, 20)
        Me.ToolStripMenuItem7.Text = "Projects"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(171, 22)
        Me.ToolStripMenuItem8.Text = "Active"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(171, 22)
        Me.ToolStripMenuItem9.Text = "Inactive"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(171, 22)
        Me.ToolStripMenuItem10.Text = "All"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(171, 22)
        Me.ToolStripMenuItem11.Text = "Current Fiscal Year"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(57, 20)
        Me.ToolStripMenuItem12.Text = "Reports"
        '
        'imlFunding
        '
        Me.imlFunding.ImageStream = CType(resources.GetObject("imlFunding.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imlFunding.TransparentColor = System.Drawing.Color.Transparent
        Me.imlFunding.Images.SetKeyName(0, "redflag")
        Me.imlFunding.Images.SetKeyName(1, "addfile")
        Me.imlFunding.Images.SetKeyName(2, " delete")
        Me.imlFunding.Images.SetKeyName(3, "modify")
        Me.imlFunding.Images.SetKeyName(4, "save")
        Me.imlFunding.Images.SetKeyName(5, "Page")
        '
        'ofdWorksPhoto
        '
        Me.ofdWorksPhoto.FileName = "OpenFileDialog1"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = true
        Me.LinkLabel3.Location = New System.Drawing.Point(868, 43)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(73, 18)
        Me.LinkLabel3.TabIndex = 396
        Me.LinkLabel3.TabStop = true
        Me.LinkLabel3.Text = "LinkLabel2"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = true
        Me.LinkLabel4.Location = New System.Drawing.Point(1084, 72)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(31, 18)
        Me.LinkLabel4.TabIndex = 395
        Me.LinkLabel4.TabStop = true
        Me.LinkLabel4.Text = "&edit"
        '
        'Label40
        '
        Me.Label40.AutoSize = true
        Me.Label40.Location = New System.Drawing.Point(769, 72)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(93, 18)
        Me.Label40.TabIndex = 394
        Me.Label40.Text = "Project User:"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = true
        Me.LinkLabel5.Location = New System.Drawing.Point(1084, 130)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(31, 18)
        Me.LinkLabel5.TabIndex = 389
        Me.LinkLabel5.TabStop = true
        Me.LinkLabel5.Text = "&edit"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = true
        Me.LinkLabel6.Location = New System.Drawing.Point(1084, 101)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(31, 18)
        Me.LinkLabel6.TabIndex = 388
        Me.LinkLabel6.TabStop = true
        Me.LinkLabel6.Text = "&edit"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = true
        Me.LinkLabel7.Location = New System.Drawing.Point(1084, 43)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(31, 18)
        Me.LinkLabel7.TabIndex = 387
        Me.LinkLabel7.TabStop = true
        Me.LinkLabel7.Text = "&edit"
        '
        'Label41
        '
        Me.Label41.AutoSize = true
        Me.Label41.Location = New System.Drawing.Point(787, 131)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(75, 18)
        Me.Label41.TabIndex = 385
        Me.Label41.Text = "Secretary:"
        '
        'Label42
        '
        Me.Label42.AutoSize = true
        Me.Label42.Location = New System.Drawing.Point(722, 102)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(140, 18)
        Me.Label42.TabIndex = 384
        Me.Label42.Text = "Architect / Engineer:"
        '
        'Label43
        '
        Me.Label43.AutoSize = true
        Me.Label43.Location = New System.Drawing.Point(742, 42)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(120, 18)
        Me.Label43.TabIndex = 383
        Me.Label43.Text = "Project Manager:"
        '
        'TextBox11
        '
        Me.TextBox11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TextBox11.Location = New System.Drawing.Point(223, 145)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = true
        Me.TextBox11.Size = New System.Drawing.Size(309, 20)
        Me.TextBox11.TabIndex = 381
        Me.TextBox11.TabStop = false
        Me.TextBox11.WordWrap = false
        '
        'TextBox21
        '
        Me.TextBox21.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox21.Location = New System.Drawing.Point(223, 114)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(100, 22)
        Me.TextBox21.TabIndex = 5
        Me.TextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox22
        '
        Me.TextBox22.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox22.Location = New System.Drawing.Point(223, 84)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(100, 22)
        Me.TextBox22.TabIndex = 4
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox23
        '
        Me.TextBox23.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox23.Location = New System.Drawing.Point(380, 53)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(37, 22)
        Me.TextBox23.TabIndex = 2
        '
        'TextBox24
        '
        Me.TextBox24.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox24.Location = New System.Drawing.Point(223, 53)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(100, 22)
        Me.TextBox24.TabIndex = 1
        '
        'TextBox25
        '
        Me.TextBox25.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox25.Location = New System.Drawing.Point(223, 176)
        Me.TextBox25.Multiline = true
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox25.Size = New System.Drawing.Size(854, 102)
        Me.TextBox25.TabIndex = 7
        '
        'TextBox26
        '
        Me.TextBox26.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.TextBox26.Location = New System.Drawing.Point(223, 22)
        Me.TextBox26.MaxLength = 50
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(433, 22)
        Me.TextBox26.TabIndex = 0
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = true
        Me.LinkLabel8.Location = New System.Drawing.Point(539, 147)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(31, 18)
        Me.LinkLabel8.TabIndex = 380
        Me.LinkLabel8.TabStop = true
        Me.LinkLabel8.Text = "&edit"
        '
        'Label44
        '
        Me.Label44.AutoSize = true
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label44.Location = New System.Drawing.Point(130, 147)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(91, 18)
        Me.Label44.TabIndex = 330
        Me.Label44.Text = "Project Type"
        '
        'Label45
        '
        Me.Label45.AutoSize = true
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label45.Location = New System.Drawing.Point(98, 118)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(124, 18)
        Me.Label45.TabIndex = 329
        Me.Label45.Text = "Last Inactive Date"
        '
        'Label46
        '
        Me.Label46.AutoSize = true
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label46.Location = New System.Drawing.Point(109, 87)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(114, 18)
        Me.Label46.TabIndex = 328
        Me.Label46.Text = "Last Active Date"
        '
        'Label47
        '
        Me.Label47.AutoSize = true
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label47.Location = New System.Drawing.Point(330, 57)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(50, 18)
        Me.Label47.TabIndex = 4
        Me.Label47.Text = "Phase"
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = true
        Me.LinkLabel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LinkLabel9.Location = New System.Drawing.Point(142, 214)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(82, 17)
        Me.LinkLabel9.TabIndex = 319
        Me.LinkLabel9.TabStop = true
        Me.LinkLabel9.Text = "&Spell Check"
        '
        'CheckBox2
        '
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(444, 55)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(68, 24)
        Me.CheckBox2.TabIndex = 3
        Me.CheckBox2.Text = "Active"
        '
        'Label48
        '
        Me.Label48.AutoSize = true
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label48.Location = New System.Drawing.Point(109, 57)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(112, 18)
        Me.Label48.TabIndex = 326
        Me.Label48.Text = "Project Number"
        '
        'Label49
        '
        Me.Label49.AutoSize = true
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label49.Location = New System.Drawing.Point(94, 174)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(129, 18)
        Me.Label49.TabIndex = 325
        Me.Label49.Text = "Status Description"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label50
        '
        Me.Label50.AutoSize = true
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label50.Location = New System.Drawing.Point(122, 24)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(99, 18)
        Me.Label50.TabIndex = 324
        Me.Label50.Text = "Project Name"
        '
        'cgdProject
        '
        Me.cgdProject.AllowUserToAddRows = false
        Me.cgdProject.AllowUserToDeleteRows = false
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(2)
        Me.cgdProject.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.cgdProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.cgdProject.Location = New System.Drawing.Point(8, 42)
        Me.cgdProject.MultiSelect = false
        Me.cgdProject.Name = "cgdProject"
        Me.cgdProject.ReadOnly = true
        Me.cgdProject.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cgdProject.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.cgdProject.RowTemplate.DefaultCellStyle.NullValue = Nothing
        Me.cgdProject.RowTemplate.DefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
        Me.cgdProject.RowTemplate.Height = 24
        Me.cgdProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.cgdProject.ShowEditingIcon = false
        Me.cgdProject.Size = New System.Drawing.Size(861, 180)
        Me.cgdProject.TabIndex = 1
        '
        'tapContractor
        '
        Me.tapContractor.BackColor = System.Drawing.SystemColors.Control
        Me.tapContractor.Controls.Add(Me.maskContractClosedDate)
        Me.tapContractor.Controls.Add(Me.maskContractConstNtp)
        Me.tapContractor.Controls.Add(Me.maskContractGenServices)
        Me.tapContractor.Controls.Add(Me.maskContractWarrantyPeriodEnds)
        Me.tapContractor.Controls.Add(Me.maskContractConstBidAward)
        Me.tapContractor.Controls.Add(Me.maskContractBidOpening)
        Me.tapContractor.Controls.Add(Me.maskContractFinalPayment)
        Me.tapContractor.Controls.Add(Me.maskContractAssbApproval)
        Me.tapContractor.Controls.Add(Me.maskContractAdvertiseBid)
        Me.tapContractor.Controls.Add(Me.maskContractSubstantialCompletion)
        Me.tapContractor.Controls.Add(Me.maskContractAgendaSetting)
        Me.tapContractor.Controls.Add(Me.maskContractOriginalBid)
        Me.tapContractor.Controls.Add(Me.cboContractor)
        Me.tapContractor.Controls.Add(Me.lnkEditContractor)
        Me.tapContractor.Controls.Add(Me.txtConstComplete)
        Me.tapContractor.Controls.Add(Me.txtContractCO)
        Me.tapContractor.Controls.Add(Me.txtContractAmount)
        Me.tapContractor.Controls.Add(Me.Label16)
        Me.tapContractor.Controls.Add(Me.Label17)
        Me.tapContractor.Controls.Add(Me.txtContractChangeOrders)
        Me.tapContractor.Controls.Add(Me.lblContractAmount)
        Me.tapContractor.Controls.Add(Me.lblContractWarPeriod)
        Me.tapContractor.Controls.Add(Me.Label15)
        Me.tapContractor.Controls.Add(Me.Label14)
        Me.tapContractor.Controls.Add(Me.Label13)
        Me.tapContractor.Controls.Add(Me.Label12)
        Me.tapContractor.Controls.Add(Me.Label11)
        Me.tapContractor.Controls.Add(Me.Label10)
        Me.tapContractor.Controls.Add(Me.Label9)
        Me.tapContractor.Controls.Add(Me.Label8)
        Me.tapContractor.Controls.Add(Me.Label7)
        Me.tapContractor.Controls.Add(Me.Label6)
        Me.tapContractor.Controls.Add(Me.Label5)
        Me.tapContractor.Location = New System.Drawing.Point(4, 24)
        Me.tapContractor.Name = "tapContractor"
        Me.tapContractor.Size = New System.Drawing.Size(857, 275)
        Me.tapContractor.TabIndex = 1
        Me.tapContractor.Text = "Contractor"
        '
        'maskContractClosedDate
        '
        Me.maskContractClosedDate.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractClosedDate.Location = New System.Drawing.Point(732, 210)
        Me.maskContractClosedDate.Mask = "00/00/0000"
        Me.maskContractClosedDate.Name = "maskContractClosedDate"
        Me.maskContractClosedDate.Size = New System.Drawing.Size(96, 21)
        Me.maskContractClosedDate.TabIndex = 16
        Me.maskContractClosedDate.ValidatingType = GetType(Date)
        '
        'maskContractConstNtp
        '
        Me.maskContractConstNtp.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractConstNtp.Location = New System.Drawing.Point(430, 210)
        Me.maskContractConstNtp.Mask = "00/00/0000"
        Me.maskContractConstNtp.Name = "maskContractConstNtp"
        Me.maskContractConstNtp.Size = New System.Drawing.Size(95, 21)
        Me.maskContractConstNtp.TabIndex = 12
        Me.maskContractConstNtp.ValidatingType = GetType(Date)
        '
        'maskContractGenServices
        '
        Me.maskContractGenServices.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractGenServices.Location = New System.Drawing.Point(154, 208)
        Me.maskContractGenServices.Mask = "00/00/0000"
        Me.maskContractGenServices.Name = "maskContractGenServices"
        Me.maskContractGenServices.Size = New System.Drawing.Size(95, 21)
        Me.maskContractGenServices.TabIndex = 8
        Me.maskContractGenServices.ValidatingType = GetType(Date)
        '
        'maskContractWarrantyPeriodEnds
        '
        Me.maskContractWarrantyPeriodEnds.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractWarrantyPeriodEnds.Location = New System.Drawing.Point(732, 184)
        Me.maskContractWarrantyPeriodEnds.Mask = "00/00/0000"
        Me.maskContractWarrantyPeriodEnds.Name = "maskContractWarrantyPeriodEnds"
        Me.maskContractWarrantyPeriodEnds.Size = New System.Drawing.Size(96, 21)
        Me.maskContractWarrantyPeriodEnds.TabIndex = 15
        Me.maskContractWarrantyPeriodEnds.ValidatingType = GetType(Date)
        '
        'maskContractConstBidAward
        '
        Me.maskContractConstBidAward.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractConstBidAward.Location = New System.Drawing.Point(430, 184)
        Me.maskContractConstBidAward.Mask = "00/00/0000"
        Me.maskContractConstBidAward.Name = "maskContractConstBidAward"
        Me.maskContractConstBidAward.Size = New System.Drawing.Size(95, 21)
        Me.maskContractConstBidAward.TabIndex = 11
        Me.maskContractConstBidAward.ValidatingType = GetType(Date)
        '
        'maskContractBidOpening
        '
        Me.maskContractBidOpening.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractBidOpening.Location = New System.Drawing.Point(154, 182)
        Me.maskContractBidOpening.Mask = "00/00/0000"
        Me.maskContractBidOpening.Name = "maskContractBidOpening"
        Me.maskContractBidOpening.Size = New System.Drawing.Size(95, 21)
        Me.maskContractBidOpening.TabIndex = 7
        Me.maskContractBidOpening.ValidatingType = GetType(Date)
        '
        'maskContractFinalPayment
        '
        Me.maskContractFinalPayment.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractFinalPayment.Location = New System.Drawing.Point(732, 158)
        Me.maskContractFinalPayment.Mask = "00/00/0000"
        Me.maskContractFinalPayment.Name = "maskContractFinalPayment"
        Me.maskContractFinalPayment.Size = New System.Drawing.Size(96, 21)
        Me.maskContractFinalPayment.TabIndex = 14
        Me.maskContractFinalPayment.ValidatingType = GetType(Date)
        '
        'maskContractAssbApproval
        '
        Me.maskContractAssbApproval.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractAssbApproval.Location = New System.Drawing.Point(430, 158)
        Me.maskContractAssbApproval.Mask = "00/00/0000"
        Me.maskContractAssbApproval.Name = "maskContractAssbApproval"
        Me.maskContractAssbApproval.Size = New System.Drawing.Size(95, 21)
        Me.maskContractAssbApproval.TabIndex = 10
        Me.maskContractAssbApproval.ValidatingType = GetType(Date)
        '
        'maskContractAdvertiseBid
        '
        Me.maskContractAdvertiseBid.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractAdvertiseBid.Location = New System.Drawing.Point(154, 156)
        Me.maskContractAdvertiseBid.Mask = "00/00/0000"
        Me.maskContractAdvertiseBid.Name = "maskContractAdvertiseBid"
        Me.maskContractAdvertiseBid.Size = New System.Drawing.Size(95, 21)
        Me.maskContractAdvertiseBid.TabIndex = 6
        Me.maskContractAdvertiseBid.ValidatingType = GetType(Date)
        '
        'maskContractSubstantialCompletion
        '
        Me.maskContractSubstantialCompletion.Font = New System.Drawing.Font("Arial", 9!)
        Me.ErrorProvider1.SetIconAlignment(Me.maskContractSubstantialCompletion, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.maskContractSubstantialCompletion.Location = New System.Drawing.Point(732, 132)
        Me.maskContractSubstantialCompletion.Mask = "00/00/0000"
        Me.maskContractSubstantialCompletion.Name = "maskContractSubstantialCompletion"
        Me.maskContractSubstantialCompletion.Size = New System.Drawing.Size(96, 21)
        Me.maskContractSubstantialCompletion.TabIndex = 13
        Me.maskContractSubstantialCompletion.ValidatingType = GetType(Date)
        '
        'maskContractAgendaSetting
        '
        Me.maskContractAgendaSetting.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractAgendaSetting.Location = New System.Drawing.Point(430, 132)
        Me.maskContractAgendaSetting.Mask = "00/00/0000"
        Me.maskContractAgendaSetting.Name = "maskContractAgendaSetting"
        Me.maskContractAgendaSetting.Size = New System.Drawing.Size(95, 21)
        Me.maskContractAgendaSetting.TabIndex = 9
        Me.maskContractAgendaSetting.ValidatingType = GetType(Date)
        '
        'maskContractOriginalBid
        '
        Me.maskContractOriginalBid.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskContractOriginalBid.Location = New System.Drawing.Point(154, 130)
        Me.maskContractOriginalBid.Mask = "00/00/0000"
        Me.maskContractOriginalBid.Name = "maskContractOriginalBid"
        Me.maskContractOriginalBid.Size = New System.Drawing.Size(95, 21)
        Me.maskContractOriginalBid.TabIndex = 5
        Me.maskContractOriginalBid.ValidatingType = GetType(Date)
        '
        'cboContractor
        '
        Me.cboContractor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboContractor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractor.FormattingEnabled = true
        Me.cboContractor.Location = New System.Drawing.Point(154, 19)
        Me.cboContractor.Name = "cboContractor"
        Me.cboContractor.Size = New System.Drawing.Size(368, 23)
        Me.cboContractor.TabIndex = 0
        '
        'lnkEditContractor
        '
        Me.lnkEditContractor.AutoSize = true
        Me.lnkEditContractor.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lnkEditContractor.Location = New System.Drawing.Point(527, 21)
        Me.lnkEditContractor.Name = "lnkEditContractor"
        Me.lnkEditContractor.Size = New System.Drawing.Size(25, 13)
        Me.lnkEditContractor.TabIndex = 1
        Me.lnkEditContractor.TabStop = true
        Me.lnkEditContractor.Text = "edit"
        '
        'txtConstComplete
        '
        Me.txtConstComplete.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtConstComplete.Location = New System.Drawing.Point(154, 104)
        Me.txtConstComplete.Name = "txtConstComplete"
        Me.txtConstComplete.Size = New System.Drawing.Size(51, 21)
        Me.txtConstComplete.TabIndex = 4
        Me.txtConstComplete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContractCO
        '
        Me.txtContractCO.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtContractCO.Location = New System.Drawing.Point(154, 75)
        Me.txtContractCO.Name = "txtContractCO"
        Me.txtContractCO.Size = New System.Drawing.Size(112, 21)
        Me.txtContractCO.TabIndex = 3
        Me.txtContractCO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContractAmount
        '
        Me.txtContractAmount.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtContractAmount.Location = New System.Drawing.Point(154, 47)
        Me.txtContractAmount.Name = "txtContractAmount"
        Me.txtContractAmount.Size = New System.Drawing.Size(112, 21)
        Me.txtContractAmount.TabIndex = 2
        Me.txtContractAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = true
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 105)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 15)
        Me.Label16.TabIndex = 166
        Me.Label16.Text = "Const % Complete"
        '
        'Label17
        '
        Me.Label17.AutoSize = true
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label17.Location = New System.Drawing.Point(569, 211)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 15)
        Me.Label17.TabIndex = 163
        Me.Label17.Text = "Closed Date"
        '
        'txtContractChangeOrders
        '
        Me.txtContractChangeOrders.AutoSize = true
        Me.txtContractChangeOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtContractChangeOrders.Location = New System.Drawing.Point(21, 78)
        Me.txtContractChangeOrders.Name = "txtContractChangeOrders"
        Me.txtContractChangeOrders.Size = New System.Drawing.Size(90, 15)
        Me.txtContractChangeOrders.TabIndex = 161
        Me.txtContractChangeOrders.Text = "Change Orders"
        '
        'lblContractAmount
        '
        Me.lblContractAmount.AutoSize = true
        Me.lblContractAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblContractAmount.Location = New System.Drawing.Point(21, 51)
        Me.lblContractAmount.Name = "lblContractAmount"
        Me.lblContractAmount.Size = New System.Drawing.Size(97, 15)
        Me.lblContractAmount.TabIndex = 158
        Me.lblContractAmount.Text = "Contract Amount"
        '
        'lblContractWarPeriod
        '
        Me.lblContractWarPeriod.AutoSize = true
        Me.lblContractWarPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblContractWarPeriod.Location = New System.Drawing.Point(569, 188)
        Me.lblContractWarPeriod.Name = "lblContractWarPeriod"
        Me.lblContractWarPeriod.Size = New System.Drawing.Size(133, 15)
        Me.lblContractWarPeriod.TabIndex = 31
        Me.lblContractWarPeriod.Text = "Correction Period Ends"
        '
        'Label15
        '
        Me.Label15.AutoSize = true
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label15.Location = New System.Drawing.Point(569, 164)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(114, 15)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Final Payment Date"
        '
        'Label14
        '
        Me.Label14.AutoSize = true
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label14.Location = New System.Drawing.Point(569, 139)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(134, 15)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Substantial Completion"
        '
        'Label13
        '
        Me.Label13.AutoSize = true
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label13.Location = New System.Drawing.Point(273, 211)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 15)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Construction N-T-P"
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label12.Location = New System.Drawing.Point(273, 187)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 15)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Construction Bid Award"
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label11.Location = New System.Drawing.Point(273, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 15)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Assembly Approval"
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label10.Location = New System.Drawing.Point(273, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 15)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Agenda Setting"
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Bid Opening Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Advertise Bid Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Original Bid Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Gen. Serv. Review"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Contractor"
        '
        'tapConsultant
        '
        Me.tapConsultant.BackColor = System.Drawing.SystemColors.Control
        Me.tapConsultant.Controls.Add(Me.maskConsultIfbRfq)
        Me.tapConsultant.Controls.Add(Me.maskConsultDesignCompleted)
        Me.tapConsultant.Controls.Add(Me.maskConsultAward)
        Me.tapConsultant.Controls.Add(Me.maskConsultRFPDate)
        Me.tapConsultant.Controls.Add(Me.maskConsultScopeApproval)
        Me.tapConsultant.Controls.Add(Me.cboConsultant)
        Me.tapConsultant.Controls.Add(Me.lnkEditConsultant)
        Me.tapConsultant.Controls.Add(Me.txtRFPNo)
        Me.tapConsultant.Controls.Add(Me.txtConsultContractAmend)
        Me.tapConsultant.Controls.Add(Me.txtConsultFee)
        Me.tapConsultant.Controls.Add(Me.txtConsultDesignCompPercent)
        Me.tapConsultant.Controls.Add(Me.lblConsultRFP)
        Me.tapConsultant.Controls.Add(Me.Label27)
        Me.tapConsultant.Controls.Add(Me.cboRFPDiscipline)
        Me.tapConsultant.Controls.Add(Me.Label26)
        Me.tapConsultant.Controls.Add(Me.lblConAmend)
        Me.tapConsultant.Controls.Add(Me.lblConFee)
        Me.tapConsultant.Controls.Add(Me.lblIFB)
        Me.tapConsultant.Controls.Add(Me.lblDesignComplete)
        Me.tapConsultant.Controls.Add(Me.lblDesignComp)
        Me.tapConsultant.Controls.Add(Me.lblConAward)
        Me.tapConsultant.Controls.Add(Me.lblScope)
        Me.tapConsultant.Controls.Add(Me.lblConsultant)
        Me.tapConsultant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tapConsultant.Location = New System.Drawing.Point(4, 24)
        Me.tapConsultant.Name = "tapConsultant"
        Me.tapConsultant.Size = New System.Drawing.Size(857, 275)
        Me.tapConsultant.TabIndex = 0
        Me.tapConsultant.Text = "Consultant"
        '
        'maskConsultIfbRfq
        '
        Me.maskConsultIfbRfq.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskConsultIfbRfq.Location = New System.Drawing.Point(156, 151)
        Me.maskConsultIfbRfq.Mask = "00/00/0000"
        Me.maskConsultIfbRfq.Name = "maskConsultIfbRfq"
        Me.maskConsultIfbRfq.Size = New System.Drawing.Size(96, 21)
        Me.maskConsultIfbRfq.TabIndex = 6
        Me.maskConsultIfbRfq.ValidatingType = GetType(Date)
        '
        'maskConsultDesignCompleted
        '
        Me.maskConsultDesignCompleted.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskConsultDesignCompleted.Location = New System.Drawing.Point(156, 125)
        Me.maskConsultDesignCompleted.Mask = "00/00/0000"
        Me.maskConsultDesignCompleted.Name = "maskConsultDesignCompleted"
        Me.maskConsultDesignCompleted.Size = New System.Drawing.Size(96, 21)
        Me.maskConsultDesignCompleted.TabIndex = 5
        Me.maskConsultDesignCompleted.ValidatingType = GetType(Date)
        '
        'maskConsultAward
        '
        Me.maskConsultAward.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskConsultAward.Location = New System.Drawing.Point(156, 74)
        Me.maskConsultAward.Mask = "00/00/0000"
        Me.maskConsultAward.Name = "maskConsultAward"
        Me.maskConsultAward.Size = New System.Drawing.Size(96, 21)
        Me.maskConsultAward.TabIndex = 3
        Me.maskConsultAward.ValidatingType = GetType(Date)
        '
        'maskConsultRFPDate
        '
        Me.maskConsultRFPDate.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskConsultRFPDate.Location = New System.Drawing.Point(493, 75)
        Me.maskConsultRFPDate.Mask = "00/00/0000"
        Me.maskConsultRFPDate.Name = "maskConsultRFPDate"
        Me.maskConsultRFPDate.Size = New System.Drawing.Size(95, 21)
        Me.maskConsultRFPDate.TabIndex = 9
        Me.maskConsultRFPDate.ValidatingType = GetType(Date)
        '
        'maskConsultScopeApproval
        '
        Me.maskConsultScopeApproval.AsciiOnly = true
        Me.maskConsultScopeApproval.Font = New System.Drawing.Font("Arial", 9!)
        Me.maskConsultScopeApproval.Location = New System.Drawing.Point(156, 49)
        Me.maskConsultScopeApproval.Mask = "00/00/0000"
        Me.maskConsultScopeApproval.Name = "maskConsultScopeApproval"
        Me.maskConsultScopeApproval.Size = New System.Drawing.Size(96, 21)
        Me.maskConsultScopeApproval.TabIndex = 2
        Me.maskConsultScopeApproval.ValidatingType = GetType(Date)
        '
        'cboConsultant
        '
        Me.cboConsultant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboConsultant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsultant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsultant.Font = New System.Drawing.Font("Arial", 9!)
        Me.cboConsultant.FormattingEnabled = true
        Me.cboConsultant.Location = New System.Drawing.Point(156, 21)
        Me.cboConsultant.Name = "cboConsultant"
        Me.cboConsultant.Size = New System.Drawing.Size(330, 23)
        Me.cboConsultant.TabIndex = 0
        '
        'lnkEditConsultant
        '
        Me.lnkEditConsultant.AutoSize = true
        Me.lnkEditConsultant.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lnkEditConsultant.Location = New System.Drawing.Point(491, 24)
        Me.lnkEditConsultant.Name = "lnkEditConsultant"
        Me.lnkEditConsultant.Size = New System.Drawing.Size(25, 13)
        Me.lnkEditConsultant.TabIndex = 1
        Me.lnkEditConsultant.TabStop = true
        Me.lnkEditConsultant.Text = "&edit"
        '
        'txtRFPNo
        '
        Me.txtRFPNo.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtRFPNo.Location = New System.Drawing.Point(493, 100)
        Me.txtRFPNo.Name = "txtRFPNo"
        Me.txtRFPNo.Size = New System.Drawing.Size(95, 21)
        Me.txtRFPNo.TabIndex = 10
        Me.txtRFPNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConsultContractAmend
        '
        Me.txtConsultContractAmend.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtConsultContractAmend.Location = New System.Drawing.Point(156, 202)
        Me.txtConsultContractAmend.Name = "txtConsultContractAmend"
        Me.txtConsultContractAmend.Size = New System.Drawing.Size(126, 21)
        Me.txtConsultContractAmend.TabIndex = 8
        Me.txtConsultContractAmend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConsultFee
        '
        Me.txtConsultFee.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtConsultFee.Location = New System.Drawing.Point(156, 176)
        Me.txtConsultFee.Name = "txtConsultFee"
        Me.txtConsultFee.Size = New System.Drawing.Size(126, 21)
        Me.txtConsultFee.TabIndex = 7
        Me.txtConsultFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConsultDesignCompPercent
        '
        Me.txtConsultDesignCompPercent.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtConsultDesignCompPercent.Location = New System.Drawing.Point(156, 100)
        Me.txtConsultDesignCompPercent.Name = "txtConsultDesignCompPercent"
        Me.txtConsultDesignCompPercent.Size = New System.Drawing.Size(35, 21)
        Me.txtConsultDesignCompPercent.TabIndex = 4
        Me.txtConsultDesignCompPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConsultRFP
        '
        Me.lblConsultRFP.AutoSize = true
        Me.lblConsultRFP.Location = New System.Drawing.Point(389, 77)
        Me.lblConsultRFP.Name = "lblConsultRFP"
        Me.lblConsultRFP.Size = New System.Drawing.Size(72, 13)
        Me.lblConsultRFP.TabIndex = 44
        Me.lblConsultRFP.Text = "RFP Bid Date"
        '
        'Label27
        '
        Me.Label27.AutoSize = true
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label27.Location = New System.Drawing.Point(389, 128)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 15)
        Me.Label27.TabIndex = 41
        Me.Label27.Text = " RFP Discipline"
        '
        'cboRFPDiscipline
        '
        Me.cboRFPDiscipline.Font = New System.Drawing.Font("Arial", 9!)
        Me.cboRFPDiscipline.FormattingEnabled = true
        Me.cboRFPDiscipline.Location = New System.Drawing.Point(493, 126)
        Me.cboRFPDiscipline.Name = "cboRFPDiscipline"
        Me.cboRFPDiscipline.Size = New System.Drawing.Size(127, 23)
        Me.cboRFPDiscipline.TabIndex = 11
        '
        'Label26
        '
        Me.Label26.AutoSize = true
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label26.Location = New System.Drawing.Point(389, 101)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(79, 15)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "RFP Number"
        '
        'lblConAmend
        '
        Me.lblConAmend.AutoSize = true
        Me.lblConAmend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblConAmend.Location = New System.Drawing.Point(18, 203)
        Me.lblConAmend.Name = "lblConAmend"
        Me.lblConAmend.Size = New System.Drawing.Size(80, 15)
        Me.lblConAmend.TabIndex = 35
        Me.lblConAmend.Text = "Amendments"
        '
        'lblConFee
        '
        Me.lblConFee.AutoSize = true
        Me.lblConFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblConFee.Location = New System.Drawing.Point(18, 178)
        Me.lblConFee.Name = "lblConFee"
        Me.lblConFee.Size = New System.Drawing.Size(28, 15)
        Me.lblConFee.TabIndex = 34
        Me.lblConFee.Text = "Fee"
        '
        'lblIFB
        '
        Me.lblIFB.AutoSize = true
        Me.lblIFB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblIFB.Location = New System.Drawing.Point(18, 152)
        Me.lblIFB.Name = "lblIFB"
        Me.lblIFB.Size = New System.Drawing.Size(60, 15)
        Me.lblIFB.TabIndex = 30
        Me.lblIFB.Text = "RFP Date"
        '
        'lblDesignComplete
        '
        Me.lblDesignComplete.AutoSize = true
        Me.lblDesignComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDesignComplete.Location = New System.Drawing.Point(18, 125)
        Me.lblDesignComplete.Name = "lblDesignComplete"
        Me.lblDesignComplete.Size = New System.Drawing.Size(109, 15)
        Me.lblDesignComplete.TabIndex = 27
        Me.lblDesignComplete.Text = "Design Completed"
        '
        'lblDesignComp
        '
        Me.lblDesignComp.AutoSize = true
        Me.lblDesignComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDesignComp.Location = New System.Drawing.Point(18, 101)
        Me.lblDesignComp.Name = "lblDesignComp"
        Me.lblDesignComp.Size = New System.Drawing.Size(116, 15)
        Me.lblDesignComp.TabIndex = 26
        Me.lblDesignComp.Text = "Design % Complete"
        '
        'lblConAward
        '
        Me.lblConAward.AutoSize = true
        Me.lblConAward.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblConAward.Location = New System.Drawing.Point(17, 77)
        Me.lblConAward.Name = "lblConAward"
        Me.lblConAward.Size = New System.Drawing.Size(116, 15)
        Me.lblConAward.TabIndex = 25
        Me.lblConAward.Text = "Consultant Awarded"
        '
        'lblScope
        '
        Me.lblScope.AutoSize = true
        Me.lblScope.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblScope.Location = New System.Drawing.Point(17, 50)
        Me.lblScope.Name = "lblScope"
        Me.lblScope.Size = New System.Drawing.Size(92, 15)
        Me.lblScope.TabIndex = 24
        Me.lblScope.Text = "Scope Approval"
        '
        'lblConsultant
        '
        Me.lblConsultant.AutoSize = true
        Me.lblConsultant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblConsultant.Location = New System.Drawing.Point(17, 23)
        Me.lblConsultant.Name = "lblConsultant"
        Me.lblConsultant.Size = New System.Drawing.Size(65, 15)
        Me.lblConsultant.TabIndex = 23
        Me.lblConsultant.Text = "Consultant"
        '
        'tapScope
        '
        Me.tapScope.BackColor = System.Drawing.SystemColors.Control
        Me.tapScope.Controls.Add(Me.scopeSpell)
        Me.tapScope.Controls.Add(Me.txtProjectScope)
        Me.tapScope.Location = New System.Drawing.Point(4, 24)
        Me.tapScope.Name = "tapScope"
        Me.tapScope.Size = New System.Drawing.Size(857, 275)
        Me.tapScope.TabIndex = 5
        Me.tapScope.Text = "Scope"
        '
        'scopeSpell
        '
        Me.scopeSpell.AutoSize = true
        Me.scopeSpell.Font = New System.Drawing.Font("Arial", 9!)
        Me.scopeSpell.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.scopeSpell.Location = New System.Drawing.Point(757, 13)
        Me.scopeSpell.Name = "scopeSpell"
        Me.scopeSpell.Size = New System.Drawing.Size(73, 15)
        Me.scopeSpell.TabIndex = 1
        Me.scopeSpell.TabStop = true
        Me.scopeSpell.Text = "Spell Check"
        '
        'txtProjectScope
        '
        Me.txtProjectScope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProjectScope.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtProjectScope.Location = New System.Drawing.Point(18, 30)
        Me.txtProjectScope.Multiline = true
        Me.txtProjectScope.Name = "txtProjectScope"
        Me.txtProjectScope.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProjectScope.Size = New System.Drawing.Size(816, 234)
        Me.spellControl.SetSpellChecking(Me.txtProjectScope, true)
        Me.txtProjectScope.TabIndex = 0
        '
        'tapProject
        '
        Me.tapProject.BackColor = System.Drawing.SystemColors.Control
        Me.tapProject.Controls.Add(Me.inactiveDatePicker)
        Me.tapProject.Controls.Add(Me.activeDatePicker)
        Me.tapProject.Controls.Add(Me.Label51)
        Me.tapProject.Controls.Add(Me.cgdAgg)
        Me.tapProject.Controls.Add(Me.ManagerLink)
        Me.tapProject.Controls.Add(Me.secretaryEdit)
        Me.tapProject.Controls.Add(Me.ArcLink)
        Me.tapProject.Controls.Add(Me.UserEditLink)
        Me.tapProject.Controls.Add(Me.Label38)
        Me.tapProject.Controls.Add(Me.Label37)
        Me.tapProject.Controls.Add(Me.Label36)
        Me.tapProject.Controls.Add(Me.Label1)
        Me.tapProject.Controls.Add(Me.cboSecretary)
        Me.tapProject.Controls.Add(Me.cboArchitect)
        Me.tapProject.Controls.Add(Me.cboProjectManager)
        Me.tapProject.Controls.Add(Me.cboProjectUser)
        Me.tapProject.Controls.Add(Me.cboProjectType)
        Me.tapProject.Controls.Add(Me.lnkEditType)
        Me.tapProject.Controls.Add(Me.lblType)
        Me.tapProject.Controls.Add(Me.cgdFund)
        Me.tapProject.Controls.Add(Me.chkProjectComplete)
        Me.tapProject.Controls.Add(Me.activestatusCheckbox)
        Me.tapProject.Controls.Add(Me.fundmanageLink)
        Me.tapProject.Controls.Add(Me.txtProjectNumber)
        Me.tapProject.Controls.Add(Me.txtProjectStatusDesc)
        Me.tapProject.Controls.Add(Me.txtProjectName)
        Me.tapProject.Controls.Add(Me.Label30)
        Me.tapProject.Controls.Add(Me.lblActiveDate)
        Me.tapProject.Controls.Add(Me.statusSpell)
        Me.tapProject.Controls.Add(Me.lblProjectNo)
        Me.tapProject.Controls.Add(Me.Label39)
        Me.tapProject.Controls.Add(Me.Label3)
        Me.tapProject.Controls.Add(Me.lblProjectTitle)
        Me.tapProject.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tapProject.Location = New System.Drawing.Point(4, 24)
        Me.tapProject.Name = "tapProject"
        Me.tapProject.Size = New System.Drawing.Size(857, 275)
        Me.tapProject.TabIndex = 6
        Me.tapProject.Text = "Project"
        '
        'inactiveDatePicker
        '
        Me.inactiveDatePicker.AsciiOnly = true
        Me.inactiveDatePicker.Font = New System.Drawing.Font("Arial", 9!)
        Me.inactiveDatePicker.Location = New System.Drawing.Point(400, 60)
        Me.inactiveDatePicker.Mask = "00/00/0000"
        Me.inactiveDatePicker.Name = "inactiveDatePicker"
        Me.inactiveDatePicker.Size = New System.Drawing.Size(84, 21)
        Me.inactiveDatePicker.TabIndex = 4
        Me.inactiveDatePicker.ValidatingType = GetType(Date)
        '
        'activeDatePicker
        '
        Me.activeDatePicker.AsciiOnly = true
        Me.activeDatePicker.Font = New System.Drawing.Font("Arial", 9!)
        Me.activeDatePicker.Location = New System.Drawing.Point(215, 60)
        Me.activeDatePicker.Mask = "00/00/0000"
        Me.activeDatePicker.Name = "activeDatePicker"
        Me.activeDatePicker.Size = New System.Drawing.Size(85, 21)
        Me.activeDatePicker.TabIndex = 3
        Me.activeDatePicker.ValidatingType = GetType(Date)
        '
        'Label51
        '
        Me.Label51.AutoSize = true
        Me.Label51.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label51.Location = New System.Drawing.Point(3, 331)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(36, 11)
        Me.Label51.TabIndex = 439
        Me.Label51.Text = "Label51"
        '
        'cgdAgg
        '
        Me.cgdAgg.AllowUserToAddRows = false
        Me.cgdAgg.AllowUserToDeleteRows = false
        Me.cgdAgg.AllowUserToResizeColumns = false
        Me.cgdAgg.AllowUserToResizeRows = false
        Me.cgdAgg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.cgdAgg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.cgdAgg.BackgroundColor = System.Drawing.SystemColors.Control
        Me.cgdAgg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cgdAgg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal
        Me.cgdAgg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.cgdAgg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.cgdAgg.Location = New System.Drawing.Point(109, 153)
        Me.cgdAgg.MultiSelect = false
        Me.cgdAgg.Name = "cgdAgg"
        Me.cgdAgg.ReadOnly = true
        Me.cgdAgg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.cgdAgg.RowTemplate.Height = 24
        Me.cgdAgg.RowTemplate.ReadOnly = true
        Me.cgdAgg.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cgdAgg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.cgdAgg.Size = New System.Drawing.Size(236, 116)
        Me.cgdAgg.TabIndex = 438
        '
        'ManagerLink
        '
        Me.ManagerLink.AutoSize = true
        Me.ManagerLink.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.ManagerLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.ManagerLink.Location = New System.Drawing.Point(816, 41)
        Me.ManagerLink.Name = "ManagerLink"
        Me.ManagerLink.Size = New System.Drawing.Size(25, 13)
        Me.ManagerLink.TabIndex = 11
        Me.ManagerLink.TabStop = true
        Me.ManagerLink.Text = "edit"
        '
        'secretaryEdit
        '
        Me.secretaryEdit.AutoSize = true
        Me.secretaryEdit.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.secretaryEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.secretaryEdit.Location = New System.Drawing.Point(816, 99)
        Me.secretaryEdit.Name = "secretaryEdit"
        Me.secretaryEdit.Size = New System.Drawing.Size(25, 13)
        Me.secretaryEdit.TabIndex = 15
        Me.secretaryEdit.TabStop = true
        Me.secretaryEdit.Text = "edit"
        '
        'ArcLink
        '
        Me.ArcLink.AutoSize = true
        Me.ArcLink.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.ArcLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.ArcLink.Location = New System.Drawing.Point(816, 70)
        Me.ArcLink.Name = "ArcLink"
        Me.ArcLink.Size = New System.Drawing.Size(25, 13)
        Me.ArcLink.TabIndex = 13
        Me.ArcLink.TabStop = true
        Me.ArcLink.Text = "edit"
        '
        'UserEditLink
        '
        Me.UserEditLink.AutoSize = true
        Me.UserEditLink.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.UserEditLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.UserEditLink.Location = New System.Drawing.Point(816, 12)
        Me.UserEditLink.Name = "UserEditLink"
        Me.UserEditLink.Size = New System.Drawing.Size(25, 13)
        Me.UserEditLink.TabIndex = 9
        Me.UserEditLink.TabStop = true
        Me.UserEditLink.Text = "edit"
        '
        'Label38
        '
        Me.Label38.AutoSize = true
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(574, 99)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(58, 15)
        Me.Label38.TabIndex = 432
        Me.Label38.Text = "Secretary"
        '
        'Label37
        '
        Me.Label37.AutoSize = true
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(577, 70)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(55, 15)
        Me.Label37.TabIndex = 433
        Me.Label37.Text = "Arc / Eng"
        '
        'Label36
        '
        Me.Label36.AutoSize = true
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(533, 41)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(98, 15)
        Me.Label36.TabIndex = 430
        Me.Label36.Text = "Project Manager"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(602, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 431
        Me.Label1.Text = "User"
        '
        'cboSecretary
        '
        Me.cboSecretary.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSecretary.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSecretary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSecretary.Font = New System.Drawing.Font("Arial", 9!)
        Me.cboSecretary.FormattingEnabled = true
        Me.cboSecretary.Location = New System.Drawing.Point(642, 97)
        Me.cboSecretary.Name = "cboSecretary"
        Me.cboSecretary.Size = New System.Drawing.Size(167, 23)
        Me.cboSecretary.TabIndex = 14
        '
        'cboArchitect
        '
        Me.cboArchitect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboArchitect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboArchitect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboArchitect.Font = New System.Drawing.Font("Arial", 9!)
        Me.cboArchitect.FormattingEnabled = true
        Me.cboArchitect.Location = New System.Drawing.Point(642, 68)
        Me.cboArchitect.Name = "cboArchitect"
        Me.cboArchitect.Size = New System.Drawing.Size(167, 23)
        Me.cboArchitect.TabIndex = 12
        '
        'cboProjectManager
        '
        Me.cboProjectManager.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboProjectManager.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProjectManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProjectManager.Font = New System.Drawing.Font("Arial", 9!)
        Me.cboProjectManager.FormattingEnabled = true
        Me.cboProjectManager.Location = New System.Drawing.Point(642, 40)
        Me.cboProjectManager.Name = "cboProjectManager"
        Me.cboProjectManager.Size = New System.Drawing.Size(167, 23)
        Me.cboProjectManager.TabIndex = 10
        '
        'cboProjectUser
        '
        Me.cboProjectUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboProjectUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProjectUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProjectUser.Font = New System.Drawing.Font("Arial", 9!)
        Me.cboProjectUser.FormattingEnabled = true
        Me.cboProjectUser.Location = New System.Drawing.Point(642, 11)
        Me.cboProjectUser.Name = "cboProjectUser"
        Me.cboProjectUser.Size = New System.Drawing.Size(167, 23)
        Me.cboProjectUser.TabIndex = 8
        '
        'cboProjectType
        '
        Me.cboProjectType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboProjectType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProjectType.Font = New System.Drawing.Font("Arial", 9!)
        Me.cboProjectType.FormattingEnabled = true
        Me.cboProjectType.Location = New System.Drawing.Point(642, 124)
        Me.cboProjectType.Name = "cboProjectType"
        Me.cboProjectType.Size = New System.Drawing.Size(167, 23)
        Me.cboProjectType.TabIndex = 16
        '
        'lnkEditType
        '
        Me.lnkEditType.AutoSize = true
        Me.lnkEditType.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lnkEditType.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkEditType.Location = New System.Drawing.Point(816, 126)
        Me.lnkEditType.Name = "lnkEditType"
        Me.lnkEditType.Size = New System.Drawing.Size(25, 13)
        Me.lnkEditType.TabIndex = 17
        Me.lnkEditType.TabStop = true
        Me.lnkEditType.Text = "edit"
        '
        'lblType
        '
        Me.lblType.AutoSize = true
        Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblType.Location = New System.Drawing.Point(556, 126)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(74, 15)
        Me.lblType.TabIndex = 423
        Me.lblType.Text = "Project Type"
        '
        'cgdFund
        '
        Me.cgdFund.AllowDrop = true
        Me.cgdFund.AllowUserToAddRows = false
        Me.cgdFund.AllowUserToDeleteRows = false
        Me.cgdFund.AllowUserToOrderColumns = true
        Me.cgdFund.BackgroundColor = System.Drawing.SystemColors.Control
        Me.cgdFund.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cgdFund.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.cgdFund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.cgdFund.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.cgdFund.Location = New System.Drawing.Point(351, 153)
        Me.cgdFund.Name = "cgdFund"
        Me.cgdFund.RowTemplate.Height = 24
        Me.cgdFund.Size = New System.Drawing.Size(493, 116)
        Me.cgdFund.TabIndex = 422
        '
        'chkProjectComplete
        '
        Me.chkProjectComplete.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkProjectComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProjectComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkProjectComplete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkProjectComplete.Location = New System.Drawing.Point(351, 11)
        Me.chkProjectComplete.Name = "chkProjectComplete"
        Me.chkProjectComplete.Size = New System.Drawing.Size(133, 19)
        Me.chkProjectComplete.TabIndex = 2
        Me.chkProjectComplete.Text = "All Work Completed"
        Me.chkProjectComplete.UseVisualStyleBackColor = true
        '
        'activestatusCheckbox
        '
        Me.activestatusCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.activestatusCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.activestatusCheckbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.activestatusCheckbox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.activestatusCheckbox.Location = New System.Drawing.Point(17, 62)
        Me.activestatusCheckbox.Name = "activestatusCheckbox"
        Me.activestatusCheckbox.Size = New System.Drawing.Size(109, 19)
        Me.activestatusCheckbox.TabIndex = 2
        Me.activestatusCheckbox.Text = "Project Active"
        Me.activestatusCheckbox.UseVisualStyleBackColor = true
        '
        'fundmanageLink
        '
        Me.fundmanageLink.AutoSize = true
        Me.fundmanageLink.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.fundmanageLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.fundmanageLink.Location = New System.Drawing.Point(49, 189)
        Me.fundmanageLink.Name = "fundmanageLink"
        Me.fundmanageLink.Size = New System.Drawing.Size(45, 13)
        Me.fundmanageLink.TabIndex = 7
        Me.fundmanageLink.TabStop = true
        Me.fundmanageLink.Text = "&Manage"
        '
        'txtProjectNumber
        '
        Me.txtProjectNumber.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtProjectNumber.Location = New System.Drawing.Point(110, 10)
        Me.txtProjectNumber.Name = "txtProjectNumber"
        Me.txtProjectNumber.Size = New System.Drawing.Size(114, 21)
        Me.txtProjectNumber.TabIndex = 0
        '
        'txtProjectStatusDesc
        '
        Me.txtProjectStatusDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProjectStatusDesc.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtProjectStatusDesc.Location = New System.Drawing.Point(109, 86)
        Me.txtProjectStatusDesc.Multiline = true
        Me.txtProjectStatusDesc.Name = "txtProjectStatusDesc"
        Me.txtProjectStatusDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProjectStatusDesc.Size = New System.Drawing.Size(375, 55)
        Me.spellControl.SetSpellChecking(Me.txtProjectStatusDesc, true)
        Me.txtProjectStatusDesc.TabIndex = 5
        '
        'txtProjectName
        '
        Me.txtProjectName.Font = New System.Drawing.Font("Arial", 9!)
        Me.txtProjectName.Location = New System.Drawing.Point(109, 35)
        Me.txtProjectName.MaxLength = 120
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(375, 21)
        Me.txtProjectName.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = true
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(313, 63)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(77, 15)
        Me.Label30.TabIndex = 329
        Me.Label30.Text = "Inactive Date"
        '
        'lblActiveDate
        '
        Me.lblActiveDate.AutoSize = true
        Me.lblActiveDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblActiveDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblActiveDate.Location = New System.Drawing.Point(137, 63)
        Me.lblActiveDate.Name = "lblActiveDate"
        Me.lblActiveDate.Size = New System.Drawing.Size(67, 15)
        Me.lblActiveDate.TabIndex = 2
        Me.lblActiveDate.Text = "Active Date"
        '
        'statusSpell
        '
        Me.statusSpell.AutoSize = true
        Me.statusSpell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.statusSpell.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.statusSpell.Location = New System.Drawing.Point(36, 103)
        Me.statusSpell.Name = "statusSpell"
        Me.statusSpell.Size = New System.Drawing.Size(61, 13)
        Me.statusSpell.TabIndex = 6
        Me.statusSpell.TabStop = true
        Me.statusSpell.Text = "&Spell Check"
        '
        'lblProjectNo
        '
        Me.lblProjectNo.AutoSize = true
        Me.lblProjectNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblProjectNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProjectNo.Location = New System.Drawing.Point(3, 12)
        Me.lblProjectNo.Name = "lblProjectNo"
        Me.lblProjectNo.Size = New System.Drawing.Size(93, 15)
        Me.lblProjectNo.TabIndex = 326
        Me.lblProjectNo.Text = "Project Number"
        '
        'Label39
        '
        Me.Label39.AutoSize = true
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(49, 171)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(52, 15)
        Me.Label39.TabIndex = 325
        Me.Label39.Text = "Funding"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(14, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 325
        Me.Label3.Text = "Project Status"
        '
        'lblProjectTitle
        '
        Me.lblProjectTitle.AutoSize = true
        Me.lblProjectTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblProjectTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProjectTitle.Location = New System.Drawing.Point(16, 36)
        Me.lblProjectTitle.Name = "lblProjectTitle"
        Me.lblProjectTitle.Size = New System.Drawing.Size(82, 15)
        Me.lblProjectTitle.TabIndex = 324
        Me.lblProjectTitle.Text = "Project Name"
        '
        'tabSupport
        '
        Me.tabSupport.Controls.Add(Me.tapProject)
        Me.tabSupport.Controls.Add(Me.tapScope)
        Me.tabSupport.Controls.Add(Me.tapConsultant)
        Me.tabSupport.Controls.Add(Me.tapContractor)
        Me.tabSupport.Controls.Add(Me.tabReports)
        Me.tabSupport.Font = New System.Drawing.Font("Arial", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tabSupport.Location = New System.Drawing.Point(8, 259)
        Me.tabSupport.Multiline = true
        Me.tabSupport.Name = "tabSupport"
        Me.tabSupport.SelectedIndex = 0
        Me.tabSupport.Size = New System.Drawing.Size(865, 303)
        Me.tabSupport.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabSupport.TabIndex = 4
        '
        'tabReports
        '
        Me.tabReports.BackColor = System.Drawing.SystemColors.Control
        Me.tabReports.Controls.Add(Me.lnkSecretaryDetail)
        Me.tabReports.Controls.Add(Me.projectArchitectDetailReportLink)
        Me.tabReports.Controls.Add(Me.managerProjectsReport)
        Me.tabReports.Controls.Add(Me.managerDetailReportLink)
        Me.tabReports.Controls.Add(Me.secretaryProjectsReport)
        Me.tabReports.Controls.Add(Me.capitalProjectsReport)
        Me.tabReports.Controls.Add(Me.orgkeyProjectReport)
        Me.tabReports.Controls.Add(Me.estimatedBidLink)
        Me.tabReports.Controls.Add(Me.substantialCompletionLink)
        Me.tabReports.Controls.Add(Me.warrentyReport)
        Me.tabReports.Controls.Add(Me.closedProjectsLink)
        Me.tabReports.Controls.Add(Me.projectReportLink)
        Me.tabReports.Controls.Add(Me.PictureBox1)
        Me.tabReports.Controls.Add(Me.Label53)
        Me.tabReports.Location = New System.Drawing.Point(4, 24)
        Me.tabReports.Name = "tabReports"
        Me.tabReports.Size = New System.Drawing.Size(857, 275)
        Me.tabReports.TabIndex = 9
        Me.tabReports.Text = "Reports"
        '
        'lnkSecretaryDetail
        '
        Me.lnkSecretaryDetail.AutoSize = true
        Me.lnkSecretaryDetail.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lnkSecretaryDetail.Location = New System.Drawing.Point(271, 116)
        Me.lnkSecretaryDetail.Name = "lnkSecretaryDetail"
        Me.lnkSecretaryDetail.Size = New System.Drawing.Size(187, 14)
        Me.lnkSecretaryDetail.TabIndex = 4
        Me.lnkSecretaryDetail.TabStop = true
        Me.lnkSecretaryDetail.Text = "Active Projects - Secretary Detail"
        '
        'projectArchitectDetailReportLink
        '
        Me.projectArchitectDetailReportLink.AutoSize = true
        Me.projectArchitectDetailReportLink.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.projectArchitectDetailReportLink.Location = New System.Drawing.Point(271, 93)
        Me.projectArchitectDetailReportLink.Name = "projectArchitectDetailReportLink"
        Me.projectArchitectDetailReportLink.Size = New System.Drawing.Size(238, 14)
        Me.projectArchitectDetailReportLink.TabIndex = 4
        Me.projectArchitectDetailReportLink.TabStop = true
        Me.projectArchitectDetailReportLink.Text = "Active Projects - Architect/Engineer Detail"
        '
        'managerProjectsReport
        '
        Me.managerProjectsReport.AutoSize = true
        Me.managerProjectsReport.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.managerProjectsReport.Location = New System.Drawing.Point(271, 164)
        Me.managerProjectsReport.Name = "managerProjectsReport"
        Me.managerProjectsReport.Size = New System.Drawing.Size(169, 14)
        Me.managerProjectsReport.TabIndex = 6
        Me.managerProjectsReport.TabStop = true
        Me.managerProjectsReport.Text = "Active Projects - Manager List"
        '
        'managerDetailReportLink
        '
        Me.managerDetailReportLink.AutoSize = true
        Me.managerDetailReportLink.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.managerDetailReportLink.Location = New System.Drawing.Point(271, 72)
        Me.managerDetailReportLink.Name = "managerDetailReportLink"
        Me.managerDetailReportLink.Size = New System.Drawing.Size(224, 14)
        Me.managerDetailReportLink.TabIndex = 3
        Me.managerDetailReportLink.TabStop = true
        Me.managerDetailReportLink.Text = "Active Projects - Project Manager Detail"
        '
        'secretaryProjectsReport
        '
        Me.secretaryProjectsReport.AutoSize = true
        Me.secretaryProjectsReport.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.secretaryProjectsReport.Location = New System.Drawing.Point(271, 140)
        Me.secretaryProjectsReport.Name = "secretaryProjectsReport"
        Me.secretaryProjectsReport.Size = New System.Drawing.Size(175, 14)
        Me.secretaryProjectsReport.TabIndex = 5
        Me.secretaryProjectsReport.TabStop = true
        Me.secretaryProjectsReport.Text = "Active Projects - Secretary List"
        '
        'capitalProjectsReport
        '
        Me.capitalProjectsReport.AutoSize = true
        Me.capitalProjectsReport.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.capitalProjectsReport.Location = New System.Drawing.Point(104, 140)
        Me.capitalProjectsReport.Name = "capitalProjectsReport"
        Me.capitalProjectsReport.Size = New System.Drawing.Size(90, 14)
        Me.capitalProjectsReport.TabIndex = 2
        Me.capitalProjectsReport.TabStop = true
        Me.capitalProjectsReport.Text = "Capital Projects"
        '
        'orgkeyProjectReport
        '
        Me.orgkeyProjectReport.AutoSize = true
        Me.orgkeyProjectReport.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.orgkeyProjectReport.Location = New System.Drawing.Point(104, 116)
        Me.orgkeyProjectReport.Name = "orgkeyProjectReport"
        Me.orgkeyProjectReport.Size = New System.Drawing.Size(99, 14)
        Me.orgkeyProjectReport.TabIndex = 2
        Me.orgkeyProjectReport.TabStop = true
        Me.orgkeyProjectReport.Text = "Project Org Keys"
        '
        'estimatedBidLink
        '
        Me.estimatedBidLink.AutoSize = true
        Me.estimatedBidLink.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.estimatedBidLink.Location = New System.Drawing.Point(605, 114)
        Me.estimatedBidLink.Name = "estimatedBidLink"
        Me.estimatedBidLink.Size = New System.Drawing.Size(135, 14)
        Me.estimatedBidLink.TabIndex = 9
        Me.estimatedBidLink.TabStop = true
        Me.estimatedBidLink.Text = "Estimated Bid Schedule"
        '
        'substantialCompletionLink
        '
        Me.substantialCompletionLink.AutoSize = true
        Me.substantialCompletionLink.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.substantialCompletionLink.Location = New System.Drawing.Point(605, 93)
        Me.substantialCompletionLink.Name = "substantialCompletionLink"
        Me.substantialCompletionLink.Size = New System.Drawing.Size(131, 14)
        Me.substantialCompletionLink.TabIndex = 8
        Me.substantialCompletionLink.TabStop = true
        Me.substantialCompletionLink.Text = "Substantial Completion"
        '
        'warrentyReport
        '
        Me.warrentyReport.AutoSize = true
        Me.warrentyReport.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.warrentyReport.Location = New System.Drawing.Point(605, 72)
        Me.warrentyReport.Name = "warrentyReport"
        Me.warrentyReport.Size = New System.Drawing.Size(101, 14)
        Me.warrentyReport.TabIndex = 7
        Me.warrentyReport.TabStop = true
        Me.warrentyReport.Text = "Correction Period"
        '
        'closedProjectsLink
        '
        Me.closedProjectsLink.AutoSize = true
        Me.closedProjectsLink.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.closedProjectsLink.Location = New System.Drawing.Point(104, 93)
        Me.closedProjectsLink.Name = "closedProjectsLink"
        Me.closedProjectsLink.Size = New System.Drawing.Size(90, 14)
        Me.closedProjectsLink.TabIndex = 1
        Me.closedProjectsLink.TabStop = true
        Me.closedProjectsLink.Text = "Closed Projects"
        '
        'projectReportLink
        '
        Me.projectReportLink.AutoSize = true
        Me.projectReportLink.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.projectReportLink.Location = New System.Drawing.Point(104, 72)
        Me.projectReportLink.Name = "projectReportLink"
        Me.projectReportLink.Size = New System.Drawing.Size(126, 14)
        Me.projectReportLink.TabIndex = 0
        Me.projectReportLink.TabStop = true
        Me.projectReportLink.Text = "Project Update Forms"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.FNSB_Facilities_Projects.My.Resources.Resources.book_notebook
        Me.PictureBox1.Location = New System.Drawing.Point(20, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = false
        '
        'Label53
        '
        Me.Label53.AutoSize = true
        Me.Label53.Font = New System.Drawing.Font("Arial", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label53.Location = New System.Drawing.Point(53, 14)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(103, 29)
        Me.Label53.TabIndex = 1
        Me.Label53.Text = "Reports"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = true
        Me.LinkLabel2.Location = New System.Drawing.Point(393, 49)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(27, 15)
        Me.LinkLabel2.TabIndex = 4
        Me.LinkLabel2.TabStop = true
        Me.LinkLabel2.Text = "edit"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Margin = New System.Windows.Forms.Padding(3)
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 23)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = false
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 26)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Margin = New System.Windows.Forms.Padding(3)
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"),System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 26)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'projectsNavigator
        '
        Me.projectsNavigator.AddNewItem = Nothing
        Me.projectsNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.projectsNavigator.DeleteItem = Nothing
        Me.projectsNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.projectsNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.projectsNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.projectsNavigator.Location = New System.Drawing.Point(8, 225)
        Me.projectsNavigator.Margin = New System.Windows.Forms.Padding(6)
        Me.projectsNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.projectsNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.projectsNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.projectsNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.projectsNavigator.Name = "projectsNavigator"
        Me.projectsNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.projectsNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.projectsNavigator.Size = New System.Drawing.Size(206, 29)
        Me.projectsNavigator.TabIndex = 2
        Me.projectsNavigator.Text = "ProjectsNavigator"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.addprojectButton, Me.ToolStripSeparator5, Me.projectsaveButton, Me.ToolStripSeparator6, Me.undoButton, Me.BindingNavigatorSeparator2, Me.prodeleteButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(560, 225)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(278, 33)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'addprojectButton
        '
        Me.addprojectButton.Image = CType(resources.GetObject("addprojectButton.Image"),System.Drawing.Image)
        Me.addprojectButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.addprojectButton.Name = "addprojectButton"
        Me.addprojectButton.Size = New System.Drawing.Size(51, 30)
        Me.addprojectButton.Text = "New"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'projectsaveButton
        '
        Me.projectsaveButton.Image = CType(resources.GetObject("projectsaveButton.Image"),System.Drawing.Image)
        Me.projectsaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.projectsaveButton.Name = "projectsaveButton"
        Me.projectsaveButton.Size = New System.Drawing.Size(51, 30)
        Me.projectsaveButton.Text = "Save"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'undoButton
        '
        Me.undoButton.Enabled = false
        Me.undoButton.Image = CType(resources.GetObject("undoButton.Image"),System.Drawing.Image)
        Me.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.undoButton.Name = "undoButton"
        Me.undoButton.Size = New System.Drawing.Size(56, 30)
        Me.undoButton.Text = "Undo"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Margin = New System.Windows.Forms.Padding(5)
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'prodeleteButton
        '
        Me.prodeleteButton.Image = CType(resources.GetObject("prodeleteButton.Image"),System.Drawing.Image)
        Me.prodeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.prodeleteButton.Name = "prodeleteButton"
        Me.prodeleteButton.Size = New System.Drawing.Size(60, 30)
        Me.prodeleteButton.Text = "Delete"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 33)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(42, 36)
        Me.ToolStripLabel3.Text = "Status:"
        '
        'tsbSelectStatus
        '
        Me.tsbSelectStatus.BackColor = System.Drawing.SystemColors.Window
        Me.tsbSelectStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsbSelectStatus.Font = New System.Drawing.Font("Arial", 9!)
        Me.tsbSelectStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tsbSelectStatus.Items.AddRange(New Object() {"Active", "Inactive", "All"})
        Me.tsbSelectStatus.Name = "tsbSelectStatus"
        Me.tsbSelectStatus.Size = New System.Drawing.Size(142, 39)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Margin = New System.Windows.Forms.Padding(8)
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripLabel4.Text = "Filter:"
        '
        'projectfilterTextbox
        '
        Me.projectfilterTextbox.Font = New System.Drawing.Font("Arial", 9!)
        Me.projectfilterTextbox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.projectfilterTextbox.Name = "projectfilterTextbox"
        Me.projectfilterTextbox.Size = New System.Drawing.Size(178, 39)
        Me.projectfilterTextbox.ToolTipText = "Filters Project Name, Number, and Description"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator10, Me.ToolStripLabel3, Me.tsbSelectStatus, Me.ToolStripSeparator9, Me.ToolStripLabel4, Me.projectfilterTextbox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.Size = New System.Drawing.Size(882, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.builsStripLabel, Me.buildStatusLabel})
        Me.statusStrip.Location = New System.Drawing.Point(0, 571)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(882, 22)
        Me.statusStrip.TabIndex = 52
        Me.statusStrip.Text = "StatusStrip1"
        '
        'builsStripLabel
        '
        Me.builsStripLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8!)
        Me.builsStripLabel.Name = "builsStripLabel"
        Me.builsStripLabel.Size = New System.Drawing.Size(29, 17)
        Me.builsStripLabel.Text = "build"
        '
        'buildStatusLabel
        '
        Me.buildStatusLabel.AutoSize = false
        Me.buildStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.buildStatusLabel.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.buildStatusLabel.IsLink = true
        Me.buildStatusLabel.Name = "buildStatusLabel"
        Me.buildStatusLabel.Size = New System.Drawing.Size(100, 17)
        Me.buildStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = true
        Me.LinkLabel10.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LinkLabel10.Location = New System.Drawing.Point(375, 111)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(221, 18)
        Me.LinkLabel10.TabIndex = 3
        Me.LinkLabel10.TabStop = true
        Me.LinkLabel10.Text = "Active Projects - Secretary Detail"
        '
        'FrmProjectTrack
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 14)
        Me.ClientSize = New System.Drawing.Size(882, 593)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.projectsNavigator)
        Me.Controls.Add(Me.cgdProject)
        Me.Controls.Add(Me.tabSupport)
        Me.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmProjectTrack"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Public Works Project Tracking"
        CType(Me.cgdProject,System.ComponentModel.ISupportInitialize).EndInit
        Me.tapContractor.ResumeLayout(false)
        Me.tapContractor.PerformLayout
        Me.tapConsultant.ResumeLayout(false)
        Me.tapConsultant.PerformLayout
        Me.tapScope.ResumeLayout(false)
        Me.tapScope.PerformLayout
        Me.tapProject.ResumeLayout(false)
        Me.tapProject.PerformLayout
        CType(Me.cgdAgg,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cgdFund,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabSupport.ResumeLayout(false)
        Me.tabReports.ResumeLayout(false)
        Me.tabReports.PerformLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.spellControl,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorProvider1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.projectsNavigator,System.ComponentModel.ISupportInitialize).EndInit
        Me.projectsNavigator.ResumeLayout(false)
        Me.projectsNavigator.PerformLayout
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.statusStrip.ResumeLayout(false)
        Me.statusStrip.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

#End Region

    'Form Load Events
    Private Sub FrmProjectTrackLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim cPublicWorks As New PublicWorks
            _InitialLoad = True

            _modifiedList = New List(Of Integer)
            _addedList = New List(Of Integer)
            _fundsList = New List(Of Integer)

            'primary public works class called to being
            'prevents grids from causing gridrow selects from firing inadvertantly

            'Load the combos for the primary tab
            LoadManagerCombo()
            LoadArcitectEngineerCombo()
            LoadSecretaryCombo()
            LoadUserCombo()
            LoadConsultantCombo()
            LoadContractorCombo()
            LoadProjectTypeCombo()

            'grid data sources
            cgdProject.DataSource = _projectBinding
            cgdFund.DataSource = _fundBinding

            'Tracking Projects *************************************************************************
            _projectsDatatable = cPublicWorks.PublicWorksLoadProjects()
            _projectsDatatable.TableName = "projects"
            _projectDataset.Tables.Add(_projectsDatatable)

            'apply custom sort to overcome 2 digit year project number implementation
            ' var(productNames = From products In table.AsEnumerable())
            'select products.Field<string>("ProductName");

            'Dim service = New FNSB.Publicworks.Service.ProjectsService
            'service.ProjectNumberSort(_projectsDatatable, True)

            _projectDataset.Tables("projects").Columns.Add("icon", GetType(Bitmap))

            'Project Funds Datatable Load and assigning to Dataset       ********************************
            _fundingDatatable = cPublicWorks.PublicWorksLoadFunding()
            _fundingDatatable.TableName = "funding"
            _projectDataset.Tables.Add(_fundingDatatable)

            'add relationship to funds
            _projectDataset.Relations.Add("RelatedFunds", _
                                          _projectDataset.Tables("projects").Columns("ppm_recordid"), _
                                          _projectDataset.Tables("funding").Columns("ppm_recordid"), False)

            'project binding source, navigation, databind to grid
            _projectBinding.DataSource = _projectDataset
            _projectBinding.DataMember = "projects"
            _projectBinding.Sort = "ppm_active_date desc"

            projectsNavigator.BindingSource = _projectBinding

            _fundBinding.DataSource = _projectBinding
            _fundBinding.DataMember = "RelatedFunds"

            AddHandler tsbSelectStatus.SelectedIndexChanged, AddressOf ProjectStatusChange  'filters the datasource to active/inactive/all projects
            AddHandler _projectBinding.ListChanged, AddressOf ProjectBindingListChanged
            AddHandler _projectBinding.CurrentChanged, AddressOf ProjectSelectChanged
            'AddHandler _projectBinding.CurrentItemChanged, AddressOf ProjectRecordItemChanged

            'datatable created to obtain and store project funding total values
            _fundingAggregateDataTable = New DataTable("fundvalues")
            _projectDataset.Tables.Add(_fundingAggregateDataTable)
            _projectDataset.Tables("fundvalues").Columns.Add("Summary", GetType(String))
            _projectDataset.Tables("fundvalues").Columns.Add("Total", GetType(String))
            _projectDataset.Tables("fundvalues").Columns(1).DefaultValue = "$0.00"
            _projectDataset.Tables("fundvalues").Rows.Add("Budget")
            _projectDataset.Tables("fundvalues").Rows.Add("Expenditures")
            _projectDataset.Tables("fundvalues").Rows.Add("Encumbrances")
            _projectDataset.Tables("fundvalues").Rows.Add("Balance")

            cgdAgg.DataSource = _projectDataset
            cgdAgg.DataMember = "fundvalues"
            cgdAgg.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            _projectRowStyle = New DataGridViewCellStyle
            _projgridColCollection = New DataGridViewColumnCollection(cgdProject)
            _projgridColCollection = cgdProject.Columns()

            _projectBinding.SuspendBinding()
            _projectBinding.RaiseListChangedEvents = False

            _projgridColCollection(44).SortMode = DataGridViewColumnSortMode.Automatic
            _projgridColCollection(44).DisplayIndex = 0
            _projgridColCollection(44).HeaderText = String.Empty
            _projgridColCollection(44).Width = 25

            _projgridColCollection(0).Visible = False
            _projgridColCollection(1).Visible = False
            _projgridColCollection(2).Visible = False
            _projgridColCollection(6).Visible = False
            _projgridColCollection(5).Visible = False
            _projgridColCollection(8).Visible = False

            _projgridColCollection(2).Width = 120
            _projgridColCollection(2).Visible = True
            _projgridColCollection(2).HeaderText = "Project No."

            _projgridColCollection(3).Width = 280
            _projgridColCollection(3).Visible = True
            _projgridColCollection(3).HeaderText = "Project Name"

            _projgridColCollection(4).Width = 110
            _projgridColCollection(4).Visible = True
            _projgridColCollection(4).HeaderText = "Active Date"

            _projgridColCollection(7).Width = 435
            _projgridColCollection(7).Visible = True
            _projgridColCollection(7).HeaderText = "Status"

            For i = 9 To 43
                _projgridColCollection(i).Visible = False
            Next

            _projectBinding.ResumeBinding()
            _projectBinding.RaiseListChangedEvents = True

            _fundgridColCollection = New DataGridViewColumnCollection(cgdFund)
            _fundgridColCollection = cgdFund.Columns()

            _fundgridColCollection(0).Visible = True
            _fundgridColCollection(0).HeaderText = "Fund"
            _fundgridColCollection(0).Width = 25

            _fundgridColCollection(1).Visible = True
            _fundgridColCollection(1).HeaderText = "Dept"
            _fundgridColCollection(1).Width = 25

            _fundgridColCollection(2).Visible = True
            _fundgridColCollection(2).HeaderText = "Key"
            _fundgridColCollection(2).Width = 60

            _fundgridColCollection(3).Visible = True
            _fundgridColCollection(3).HeaderText = "Desc."
            _fundgridColCollection(3).Width = 160

            _fundgridColCollection(4).Visible = True
            _fundgridColCollection(4).HeaderText = "Budget"
            _fundgridColCollection(4).Width = 80
            _fundgridColCollection(4).DefaultCellStyle.Format = "$###,###,###,##0.00"
            _fundgridColCollection(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            _fundgridColCollection(5).Visible = True
            _fundgridColCollection(5).HeaderText = "Expend."
            _fundgridColCollection(5).Width = 80
            _fundgridColCollection(5).DefaultCellStyle.Format = "$###,###,###,##0.00"
            _fundgridColCollection(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            _fundgridColCollection(6).Visible = True
            _fundgridColCollection(6).HeaderText = "Encumb."
            _fundgridColCollection(6).Width = 80
            _fundgridColCollection(6).DefaultCellStyle.Format = "$###,###,###,##0.00"
            _fundgridColCollection(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            _fundgridColCollection(7).Visible = True
            _fundgridColCollection(7).HeaderText = "Balance"
            _fundgridColCollection(7).Width = 80
            _fundgridColCollection(7).DefaultCellStyle.Format = "$###,###,###,##0.00"
            _fundgridColCollection(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            _fundgridColCollection(8).Visible = False
            _fundgridColCollection(9).Visible = False

            '_projectBinding.SuspendBinding()
            tsbSelectStatus.SelectedIndex = ViewState.Active
            '_projectBinding.ResumeBinding()
            'sets the load up to display Active projects only

            projectsaveButton.Image = imlFunding.Images("save")

            Dim namebinding = New Binding("Text", _projectBinding, "ppm_Project_name", True)
            txtProjectName.DataBindings.Add(namebinding)

            Dim numberbinding = New Binding("Text", _projectBinding, "ppm_Project_number", True)
            txtProjectNumber.DataBindings.Add(numberbinding)

            'status binding to checked field in the activedateTimePicker
            Dim statusbitBind As Binding = New Binding("Checked", _projectBinding, "ppm_project_active", False)
            AddHandler activestatusCheckbox.CheckStateChanged, AddressOf StatusStateChanged
            activestatusCheckbox.DataBindings.Add(statusbitBind)

            Dim statusbind = New Binding("Text", _projectBinding, "ppm_status_desc", True)
            txtProjectStatusDesc.DataBindings.Add(statusbind)

            'Active Date and Status Flag Binding to DateTimePicker
            Dim activeBind As Binding = New Binding("Text", _projectBinding, "ppm_active_date", True)
            activeDatePicker.DataBindings.Add(activeBind)
            AddHandler activeBind.Format, AddressOf DateToFullDateString
            AddHandler activeBind.Parse, AddressOf DateStringToDate

            'DataSourceUpdateMode.OnPropertyChanged might be needed
            Dim inactiveBind As Binding = New Binding("Text", _projectBinding, "ppm_inactive_date", True)
            inactiveDatePicker.DataBindings.Add(inactiveBind)
            AddHandler inactiveBind.Format, AddressOf DateToFullDateString
            AddHandler inactiveBind.Parse, AddressOf DateStringToDate

            Dim bc0 As Binding = New Binding("SelectedValue", _projectBinding, "ppr_recordid", True)
            cboProjectManager.DataBindings.Add(bc0)

            Dim bc1 As Binding = New Binding("SelectedValue", _projectBinding, "ppu_recordid", True)
            cboProjectUser.DataBindings.Add(bc1)

            Dim bc2 As Binding = New Binding("SelectedValue", _projectBinding, "pps_recordid", True)
            cboSecretary.DataBindings.Add(bc2)

            Dim bc3 As Binding = New Binding("SelectedValue", _projectBinding, "ppa_recordid", True)
            cboArchitect.DataBindings.Add(bc3)

            Dim bc4 As Binding = New Binding("SelectedValue", _projectBinding, "ppt_recordid", True)
            cboProjectType.DataBindings.Add(bc4)

            Dim bc5 As Binding = New Binding("Text", _projectBinding, "ppm_proj_scope", True)
            txtProjectScope.DataBindings.Add(bc5)

            'Consultant tab
            Dim bc7 As Binding = New Binding("SelectedValue", _projectBinding, "ppc_recordid", True)
            cboConsultant.DataBindings.Add(bc7)

            Dim b0 As Binding = New Binding("Text", _projectBinding, "ndi_scope", True)
            AddHandler b0.Format, AddressOf DateToFullDateString
            AddHandler b0.Parse, AddressOf DateStringToDate
            maskConsultScopeApproval.DataBindings.Add(b0)

            Dim b1 As Binding = New Binding("Text", _projectBinding, "ndi_consultant_award", True)
            AddHandler b1.Format, AddressOf DateToFullDateString
            AddHandler b1.Parse, AddressOf DateStringToDate
            maskConsultAward.DataBindings.Add(b1)

            Dim b2 As Binding = New Binding("Text", _projectBinding, "ndi_design_complete", True)
            AddHandler b2.Format, AddressOf DateToFullDateString
            AddHandler b2.Parse, AddressOf DateStringToDate
            maskConsultDesignCompleted.DataBindings.Add(b2)

            Dim b4 As Binding = New Binding("Text", _projectBinding, "NDI_RFP", True)
            AddHandler b4.Format, AddressOf DateToFullDateString
            AddHandler b4.Parse, AddressOf DateStringToDate
            maskConsultRFPDate.DataBindings.Add(b4)

            Dim b5 As Binding = New Binding("Text", _projectBinding, "NDI_original_bid_date", True)
            AddHandler b5.Format, AddressOf DateToFullDateString
            AddHandler b5.Parse, AddressOf DateStringToDate
            maskContractOriginalBid.DataBindings.Add(b5)

            Dim b6 As Binding = New Binding("Text", _projectBinding, "ndi_advertise_for_bid", True)
            AddHandler b6.Format, AddressOf DateToFullDateString
            AddHandler b6.Parse, AddressOf DateStringToDate
            _maskContractAdvertiseBid.DataBindings.Add(b6)

            Dim b7 As Binding = New Binding("Text", _projectBinding, "ndi_bid_opening", True)
            AddHandler b7.Format, AddressOf DateToFullDateString
            AddHandler b7.Parse, AddressOf DateStringToDate
            _maskContractBidOpening.DataBindings.Add(b7)

            Dim b8 As Binding = New Binding("Text", _projectBinding, "ndi_gen_serv_review", True)
            AddHandler b8.Format, AddressOf DateToFullDateString
            AddHandler b8.Parse, AddressOf DateStringToDate
            _maskContractGenServices.DataBindings.Add(b8)

            Dim b9 As Binding = New Binding("Text", _projectBinding, "ndi_agenda_setting", True)
            AddHandler b9.Format, AddressOf DateToFullDateString
            AddHandler b9.Parse, AddressOf DateStringToDate
            _maskContractAgendaSetting.DataBindings.Add(b9)

            Dim b10 As Binding = New Binding("Text", _projectBinding, "ndi_assembly_approval", True)
            AddHandler b10.Format, AddressOf DateToFullDateString
            AddHandler b10.Parse, AddressOf DateStringToDate
            _maskContractAssbApproval.DataBindings.Add(b10)

            Dim b11 As Binding = New Binding("Text", _projectBinding, "ndi_construction_bid_award", True)
            AddHandler b11.Format, AddressOf DateToFullDateString
            AddHandler b11.Parse, AddressOf DateStringToDate
            _maskContractConstBidAward.DataBindings.Add(b11)

            Dim b12 As Binding = New Binding("Text", _projectBinding, "ndi_ntp", True)
            AddHandler b12.Format, AddressOf DateToFullDateString
            AddHandler b12.Parse, AddressOf DateStringToDate
            _maskContractConstNtp.DataBindings.Add(b12)

            Dim b13 As Binding = New Binding("Text", _projectBinding, "ndi_substantial_completion", True)
            AddHandler b13.Format, AddressOf DateToFullDateString
            AddHandler b13.Parse, AddressOf DateStringToDate
            _maskContractSubstantialCompletion.DataBindings.Add(b13)

            Dim b14 As Binding = New Binding("Text", _projectBinding, "ndi_final", True)
            AddHandler b14.Format, AddressOf DateToFullDateString
            AddHandler b14.Parse, AddressOf DateStringToDate
            _maskContractFinalPayment.DataBindings.Add(b14)

            Dim b15 As Binding = New Binding("Text", _projectBinding, "ndi_warranty_period_ends", True)
            AddHandler b15.Format, AddressOf DateToFullDateString
            AddHandler b15.Parse, AddressOf DateStringToDate
            _maskContractWarrantyPeriodEnds.DataBindings.Add(b15)

            Dim b16 As Binding = New Binding("Text", _projectBinding, "ndi_closed", True)
            AddHandler b16.Format, AddressOf DateToFullDateString
            AddHandler b16.Parse, AddressOf DateStringToDate
            _maskContractClosedDate.DataBindings.Add(b16)

            Dim b17 As Binding = New Binding("Text", _projectBinding, "PPM_Per_Des_Complete", True)
            txtConsultDesignCompPercent.DataBindings.Add(b17)
            Dim b18 As Binding = New Binding("Text", _projectBinding, "PPM_Consultant_Fee", True)

            AddHandler b18.Format, AddressOf FundFormat
            txtConsultFee.DataBindings.Add(b18)
            Dim b19 As Binding = New Binding("Text", _projectBinding, "PPM_Contract_Amendments", True)

            AddHandler b18.Format, AddressOf FundFormat
            txtConsultContractAmend.DataBindings.Add(b19)

            'Contractor Tab
            Dim b21 As Binding = New Binding("SelectedValue", _projectBinding, "ppn_recordid", True)
            cboContractor.DataBindings.Add(b21)

            Dim b22 As Binding = New Binding("Text", _projectBinding, "ppm_contract_amount", True)
            AddHandler b18.Format, AddressOf FundFormat
            txtContractAmount.DataBindings.Add(b22)

            Dim b23 As Binding = New Binding("Text", _projectBinding, "ppm_co", True)
            AddHandler b18.Format, AddressOf FundFormat
            txtContractCO.DataBindings.Add(b23)

            Dim b24 As Binding = New Binding("Text", _projectBinding, "ppm_per_const_complete", True)
            txtConstComplete.DataBindings.Add(b24)

            Dim b25 As Binding = New Binding("Checked", _projectBinding, "ppm_project_complete", False)
            chkProjectComplete.DataBindings.Add(b25)

            'build panel deveopment to tie bugs to resolution in build
            If ApplicationDeployment.IsNetworkDeployed Then
                Dim builddata = ApplicationDeployment.CurrentDeployment.CurrentVersion
                buildStatusLabel.Text = builddata.ToString()
            End If

            _projectBinding.ResetBindings(False)
            _statusChanged = True

            txtProjectName.Focus()
            _InitialLoad = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub StatusStateChanged(ByVal sender As Object, ByVal e As EventArgs)

        If _InitialLoad Then Exit Sub


        'TODO Event is being thrown during navigation in the "view all" even when the status isn't being changed
        Try
            If _statusChanged = True Then

                Dim checkStatus As Boolean
                checkStatus = activestatusCheckbox.CheckState

                _projectBinding.RaiseListChangedEvents = False

                Dim row As DataRowView = _projectBinding.Current

                Dim s As String
                If checkStatus = True Then s = "active" Else s = "inactive"
                Dim dialog = MessageBox.Show(String.Format("Setting the project to {0} will take effect immediately and all current changes to the record will be saved. " & _
                                             "Select OK to accept and Cancel to leave unchanged.", s), PrimaryDialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

                Select Case dialog
                    Case DialogResult.Cancel
                        _projectBinding.RaiseListChangedEvents = True
                        _statusChanged = False
                        _projectBinding.ResetCurrentItem()
                        _statusChanged = True

                    Case DialogResult.OK
                        row.Row.Item("ppm_project_active") = checkStatus
                        row.Row.Item("ppm_inactive_date") = If(checkStatus = False, Today.Date, DBNull.Value)
                        row.Row.Item("ppm_active_date") = If(checkStatus = True, Today.Date, DBNull.Value)

                        Dim pworks = New PublicWorks
                        Dim result = pworks.PublicWorksUpdateProjectRow(row.Row)

                        _projectBinding.RaiseListChangedEvents = True
                        _statusChanged = False
                        _projectBinding.ResetBindings(False)
                        _statusChanged = True

                End Select
            End If

        Catch ex As Exception '
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Private Sub ProjectRecordItemChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim str = "NotImplementedException()"
    'End Sub

    Private Sub LoadArcitectEngineerCombo()

        Dim db As New publicworksEntities
        Dim arc = db.ArchitectEngineers.ToDictionary((Function(item) item.recordid), Function(item) String.Format("{0} {1}", item.firstname, item.lastname)).OrderBy(Function(item) item.Value)
        cboArchitect.DisplayMember = "Value"
        cboArchitect.ValueMember = "Key"
        cboArchitect.DataSource = arc.ToList()

    End Sub

    Private Sub LoadConsultantCombo()

        Dim db As New publicworksEntities
        Dim consult = db.Consultants.ToDictionary((Function(item) item.ppc_recordid), Function(item) String.Format("{0}", item.consultantname)).OrderBy(Function(item) item.Value)
        cboConsultant.DisplayMember = "Value"
        cboConsultant.ValueMember = "Key"
        cboConsultant.DataSource = consult.ToList()

    End Sub

    Private Sub LoadContractorCombo()

        Dim db As New Model.publicworksEntities
        Dim dictionary = db.Contractors.ToDictionary((Function(item) item.ppn_recordid), Function(item) String.Format("{0}", item.contractorname)).OrderBy(Function(item) item.Value)
        cboContractor.DisplayMember = "Value"
        cboContractor.ValueMember = "Key"
        cboContractor.DataSource = dictionary.ToList()

    End Sub

    Private Sub LoadManagerCombo()
        Dim db As New Model.publicworksEntities
        Dim mgr = db.ProjectManagers.ToDictionary((Function(item) item.ppr_recordid), Function(item) String.Format("{0} {1}", item.firstname, item.lastname)).OrderBy(Function(item) item.Value)
        cboProjectManager.DisplayMember = "Value"
        cboProjectManager.ValueMember = "Key"
        cboProjectManager.DataSource = mgr.ToList()
    End Sub

    Private Sub LoadProjectTypeCombo()
        Dim db As New Model.publicworksEntities
        Dim dictionary = db.ProjectTypes.ToDictionary((Function(item) item.ppt_recordid), Function(item) String.Format("{0}", item.category)).OrderBy(Function(item) item.Value)
        cboProjectType.DisplayMember = "Value"
        cboProjectType.ValueMember = "Key"
        cboProjectType.DataSource = dictionary.ToList()
    End Sub

    Private Sub LoadSecretaryCombo()
        Dim db As New Model.publicworksEntities
        Dim dictionary = db.Secretaries.ToDictionary((Function(item) item.pps_recordid), Function(item) String.Format("{0} {1}", item.firstname, item.lastname)).OrderBy(Function(item) item.Value)
        cboSecretary.DisplayMember = "Value"
        cboSecretary.ValueMember = "Key"
        cboSecretary.DataSource = dictionary.ToList()
    End Sub

    Private Sub LoadUserCombo()
        Dim db As New Model.publicworksEntities
        Dim dictionary = db.Users.ToDictionary((Function(item) item.ppu_recordid), Function(item) String.Format("{0} {1}", item.firstname, item.lastname)).OrderBy(Function(item) item.Value)
        cboProjectUser.DisplayMember = "Value"
        cboProjectUser.ValueMember = "Key"
        cboProjectUser.DataSource = dictionary.ToList()
    End Sub


    ''' <summary>
    ''' Adds a project to the underlying binding source / grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddprojectButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addprojectButton.Click

        'Try
        '    Validate()
        Dim [date] As DateTime = Today
        Dim id As Integer
        Dim dataRow As System.Data.DataRow

        'check for Active view display
        If _projectsViewState = ViewState.Inactive Then


            Dim stateDialog As DialogResult = MessageBox.Show(Me, InactiveAdd, PrimaryDialogTitle, _
                                                              MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If stateDialog = DialogResult.Cancel Then Exit Sub
            tsbSelectStatus.SelectedIndex = ViewState.Active

        End If

        'check datatable for added rows
        Dim rowsAdded = _projectDataset.Tables(0).GetChanges(rowStates:=DataRowState.Added)

        'added rows in the dataset - inform user that new row already in play and prompt to save
        If Not rowsAdded Is Nothing Then
            If rowsAdded.Rows.Count > 0 Then

                Dim result As DialogResult =
                    MessageBox.Show(ProjectsAddWarning, PrimaryDialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)

                Select Case result
                    Case Windows.Forms.DialogResult.OK  'save

                        'save routine for projectupdate
                        Dim works As New PublicWorks
                        Dim i As Integer

                        'add loops for add/modify here to delete bitmap prior to Update
                        If Not _addedList.Count = 0 Then
                            For i = 0 To _addedList.Count - 1
                                Dim projectRow As System.Data.DataRow =
                                        _projectDataset.Tables("projects").Rows.Find(_addedList(i))
                                projectRow.Item(44) = Nothing
                            Next
                        End If

                        'add loops for add/modify here to delete bitmap prior to Update
                        If Not _modifiedList.Count = 0 Then
                            For i = 0 To _modifiedList.Count - 1
                                Dim projectRow As System.Data.DataRow =
                                        _projectDataset.Tables("projects").Rows.Find(_modifiedList(i))
                                projectRow.Item(44) = Nothing
                            Next
                        End If

                        _projectBinding.RaiseListChangedEvents = False  'prevents change event from being raised
                        i = works.PublicWorksUpdateProjects(_projectDataset.Tables("projects"))
                        _projectBinding.RaiseListChangedEvents = True

                    Case Windows.Forms.DialogResult.Cancel  'save

                        Exit Sub

                End Select
            End If
        End If

        'init new row from the datatable setup as Active with current date and flag grid as new record
        dataRow = _projectDataset.Tables("projects").NewRow()

        dataRow.BeginEdit()
        dataRow.Item(44) = imlFunding.Images("addfile") 'addfile icon
        dataRow.Item("ppm_project_active") = 1  'status to active
        dataRow.Item("ppm_active_date") = [date]    'todays date
        dataRow.Item("ppm_project_number") = String.Empty
        dataRow.Item("ppm_project_name") = String.Empty
        dataRow.Item("ppu_recordid") = 579
        dataRow.Item("pps_recordid") = 1
        dataRow.Item("ppr_recordid") = 487
        dataRow.Item("ppc_recordid") = 407
        dataRow.Item("ppa_recordid") = 59
        dataRow.Item("ppn_recordid") = 1450
        dataRow.Item("ppm_project_complete") = 0    'project status
        dataRow.EndEdit()

        id = dataRow.Item("ppm_recordid")
        _addedList.Add(id)  'icon locations to remove during update

        'add the Active project row to the table
        _projectDataset.Tables("projects").Rows.Add(dataRow)
        ' _projectBinding.Sort = "ppm_active_date desc, ppm_recordid desc"
        _projectBinding.Position = 0
        Me.undoButton.Enabled = True

    End Sub


    'delete command on the projects
    Private Sub ProdeleteButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prodeleteButton.Click

        Try
            If _projectBinding.Current Is Nothing Then
                Throw New IndexOutOfRangeException("No current binding item while attepting to delete")
            End If

            Dim projectGridRow As DataGridViewRow
            projectGridRow = cgdProject.CurrentRow
            projectGridRow.Cells(44).Value = imlFunding.Images("redflag")

            'build and show dialog box
            Dim msgcontent As DialogResult
            msgcontent = MessageBox.Show("Selected project will be deleted. Select Yes to continue or No to cancel.",
                                          PrimaryDialogTitle, MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Exclamation)
            Select Case msgcontent
                Case Windows.Forms.DialogResult.Yes 'confirmed to delete


                    Dim projectrowDelete As DataRowView = _projectBinding.Current
                    Dim key As Integer = cgdProject.CurrentRow.Cells(0).Value
                    Dim delRow As System.Data.DataRow = _projectDataset.Tables("projects").Rows.Find(key)

                    'TODO - Casecade delete set-up in DB or DataSet
                    'uses the recordid key to find the datarow in the dataset
                    _projectBinding.RaiseListChangedEvents = False
                    delRow.Delete()
                    Dim deletedRows(0) As System.Data.DataRow
                    deletedRows(0) = delRow



                    'resume binding on the project grid and execute the update 
                    _projectBinding.RaiseListChangedEvents = True
                    Dim i As Integer
                    Dim pbworks As New PublicWorks

                    i = pbworks.PublicWorksDeleteProjects(deletedRows)
                    'executes the call to update / accept changes
                    _projectBinding.ResetBindings(False)

                Case Windows.Forms.DialogResult.No 'Reset the project as an undo

                    'used for iteration in the array loops
                    Dim i As Integer

                    'add loops for add/modify here to delete bitmap prior to Update
                    If Not _addedList.Count = 0 Then
                        For i = 0 To _addedList.Count - 1
                            Dim projectRow As System.Data.DataRow = _projectDataset.Tables("projects").Rows.Find(_addedList(i))
                            projectRow.Item(44) = Nothing
                        Next
                    End If

                    'add loops for add/modify here to delete bitmap prior to Update
                    If Not _modifiedList.Count = 0 Then
                        For i = 0 To _modifiedList.Count - 1
                            Dim projectRow As System.Data.DataRow = _projectDataset.Tables("projects").Rows.Find(_modifiedList(i))
                            projectRow.Item(44) = Nothing
                        Next
                    End If

                    _addedList.Clear()
                    _modifiedList.Clear()
                    _projectDataset.Tables("projects").RejectChanges()

                    cgdProject.Columns(44).DefaultCellStyle.ApplyStyle(_projectRowStyle)
                    _projectBinding.ResetBindings(False)
                    undoButton.Enabled = False
                    Exit Sub

            End Select

        Catch rex As IndexOutOfRangeException
            MsgBox(rex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' Returns the project bindings back to last state of accept changes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UndoButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles undoButton.Click

        Try

            'used for iteration in the array loops
            Dim i As Integer
            _projectBinding.RaiseListChangedEvents = False
            _projectBinding.EndEdit()
            'HACK whats this doing
            '_projectBinding.SuspendBinding()

            'add loops for add/modify here to delete bitmap prior to Update
            If Not _addedList.Count = 0 Then
                For i = 0 To _addedList.Count - 1
                    Dim projectRow As System.Data.DataRow = _projectDataset.Tables("projects").Rows.Find(_addedList(i))
                    projectRow.Item(44) = Nothing
                Next
            End If

            'add loops for add/modify here to delete bitmap prior to Update
            If Not _modifiedList.Count = 0 Then
                For i = 0 To _modifiedList.Count - 1
                    Dim projectRow As System.Data.DataRow = _projectDataset.Tables("projects").Rows.Find(_modifiedList(i))
                    projectRow.Item(44) = Nothing
                Next
            End If

            If Not _fundsList.Count = 0 Then
                _projectDataset.Tables("funding").RejectChanges()
                'wipe the datatable of changes
                _fundsList.Clear()
            End If

            _addedList.Clear()
            'wipe arrays to clear the catches
            _modifiedList.Clear()
            _projectDataset.Tables("projects").RejectChanges()
            'wipe the datatable of changes

            _projectBinding.RaiseListChangedEvents = True
            '_projectBinding.ResumeBinding()

            cgdProject.Columns(44).DefaultCellStyle.ApplyStyle(_projectRowStyle)
            _projectBinding.ResetBindings(False)
            undoButton.Enabled = False

        Catch ex As Exception

        End Try

    End Sub


    Public Sub ProjectSelectChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Try

            Dim view As DataRowView = _projectBinding.Current
            If view Is Nothing Then Exit Sub
            miProjectID = view(0)
            Dim pbworks As New PublicWorks
            Dim fundbalance() As Decimal = pbworks.CalculateFundBalance(view(0), _projectDataset.Tables("funding"))

            _projectDataset.Tables("fundvalues").Rows(0).Item(1) = FormatCurrency(fundbalance(0), 2)
            _projectDataset.Tables("fundvalues").Rows(1).Item(1) = FormatCurrency(fundbalance(1), 2)
            _projectDataset.Tables("fundvalues").Rows(2).Item(1) = FormatCurrency(fundbalance(2), 2)
            _projectDataset.Tables("fundvalues").Rows(3).Item(1) = FormatCurrency(fundbalance(3), 2)

        Catch ex As Exception

        End Try


    End Sub

    ''' <summary>
    ''' Project Binding Source List has changed through an Add, Delete, Modify
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="cevent"></param>
    ''' <remarks></remarks>
    Private Sub ProjectBindingListChanged(ByVal sender As Object, ByVal cevent As System.ComponentModel.ListChangedEventArgs)

        Dim prochangeType As Integer = cevent.ListChangedType
        'type of event
        Dim listIndex As Integer = cevent.NewIndex
        'grid index selected
        Dim oldIndex As Integer
        Dim recordidInt As Integer

        Try
            If Not prochangeType = System.ComponentModel.ListChangedType.Reset Then 'do not fire on resets
                Dim gridRow As DataGridViewRow = cgdProject.Rows(listIndex)
                'gets the Active datagridrow from cgdProject grid
                recordidInt = gridRow.Cells(0).Value
                'project recordid

                Select Case prochangeType
                    Case System.ComponentModel.ListChangedType.ItemChanged 'MODIFIED

                        If cevent.OldIndex = -1 Then Exit Sub
                        If Not cevent.OldIndex > 0 Then oldIndex = cevent.OldIndex
                        Dim gridoldRow As DataGridViewRow = cgdProject.Rows(oldIndex)
                        'gets the Active datagridrow from cgdProject grid

                        'add modified recordid value to array list
                        If Not _addedList.Contains(recordidInt) Then
                            If Not _addedList.Contains(recordidInt) Then
                                _modifiedList.Add(recordidInt)
                                gridRow.Cells(44).Value = imlFunding.Images("Save")
                                'user is modifying a record
                            End If
                        End If

                        undoButton.Enabled = True
                    Case System.ComponentModel.ListChangedType.ItemDeleted

                End Select
            End If

        Catch ex As ArgumentOutOfRangeException
            MsgBox("grid index error in Project grid")
        End Try

    End Sub

    ''' <summary>
    ''' ParseTool To handle the look and feel of the active_date / status check and the inactive_date status check
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="cevent"></param>
    ''' <remarks></remarks>
    Private Sub MyParseTool(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If cevent.DesiredType Is GetType(Boolean) Then
            If cevent.Value = True Then
                inactiveDatePicker.Enabled = False
            ElseIf cevent.Value = False Then
                inactiveDatePicker.Enabled = True
            End If
        End If
    End Sub


    Private Sub activedateTimePick_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'Try
        '    TimePickerSaveSign(activeDatePicker.Value)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    ''' <summary>
    ''' Called to verify DateTimePicker changes so the grid can flag the row as changed / needing saved
    ''' </summary>
    ''' <param name="timepickDate"></param>
    ''' <remarks></remarks>
    Private Sub TimePickerSaveSign(ByVal timepickDate As DateTime)

        Try
            Dim projectRowView As DataRowView = _projectBinding.Current
            Dim recordidInt As Integer

            If Not projectRowView.Item("ppm_active_date") = timepickDate Then
                Dim gridRow As DataGridViewRow = cgdProject.CurrentRow
                recordidInt = gridRow.Cells(0).Value

                If Not _modifiedList.Contains(recordidInt) Then 'add modified recordid value to array list
                    _modifiedList.Add(recordidInt)
                End If

                gridRow.Cells(44).Value = imlFunding.Images("Save")
                undoButton.Enabled = True
            End If

        Catch ex As Exception
            MsgBox("error in the TimePickerSaveSign: " & ex.Message)
        End Try

    End Sub


    Private Sub ProjectStatusChange(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            _statusChanged = False

            Select Case tsbSelectStatus.SelectedIndex
                Case 0
                    _projectBinding.Filter = "ppm_project_active = 1"
                    _projectsViewState = ViewState.Active
                Case 1
                    _projectBinding.Filter = "ppm_project_active = 0"
                    _projectsViewState = ViewState.Inactive
                Case 2
                    _projectBinding.Filter = "ppm_project_active = 0 or ppm_project_active = 1"
                    _projectsViewState = ViewState.All
            End Select

            _statusChanged = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub FundmanageLinkClicked(ByVal sender As System.Object,
                                            ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles fundmanageLink.LinkClicked

        fundmanageForm = New PublicWorksFunding(_projectDataset, miProjectID) 'fund management form
        fundmanageForm.ShowDialog()
        _projectBinding.ResetBindings(False)

    End Sub


    Private Sub ProjectsaveButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles projectsaveButton.Click

        Try

            Dim i As Integer
            _projectBinding.EndEdit()
            _projectBinding.RaiseListChangedEvents = False

            'add loops for add/modify here to delete bitmap prior to Update
            If Not _addedList.Count = 0 Then
                For i = 0 To _addedList.Count - 1
                    Dim projectRow As System.Data.DataRow = _projectDataset.Tables("projects").Rows.Find(_addedList(i))
                    projectRow.Item(44) = Nothing
                Next
            End If

            If Not _modifiedList.Count = 0 Then
                For i = 0 To _modifiedList.Count - 1
                    Dim projectRow As System.Data.DataRow = _projectDataset.Tables("projects").Rows.Find(_modifiedList(i))
                    projectRow.Item(44) = Nothing
                Next
            End If

            Dim works As New PublicWorks
            i = works.PublicWorksUpdateProjects(_projectDataset.Tables("projects"))

            _addedList.Clear()
            _modifiedList.Clear()
            _fundsList.Clear()

            _projectBinding.RaiseListChangedEvents = True
            _projectBinding.ResetBindings(False)

        Catch ex As Exception

        End Try

    End Sub




    Private Enum BalType
        oldbalance = 0
        newbalance = 1
    End Enum

    Private Sub llbSpellStatus_LinkClicked(ByVal sender As System.Object, ByVal e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles statusSpell.LinkClicked, scopeSpell.LinkClicked

        Try
            If sender.Name = "scopeSpell" Then
                Dim projspell = spellControl.CheckControl(txtProjectScope)
                If projspell = 0 Then
                    MessageBox.Show("Spell Check Completed", Resources.PrimaryDialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            ElseIf sender.Name = "statusSpell" Then
                Dim spell = spellControl.CheckControl(txtProjectStatusDesc, False)
                If spell = 0 Then
                    MessageBox.Show("Spell Check Completed", Resources.PrimaryDialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub ProjectfilterTextboxKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles projectfilterTextbox.KeyUp

        Try

            Dim textFilter As String = projectfilterTextbox.Text
            Dim statusMode As Integer = tsbSelectStatus.SelectedIndex

            Dim service As New ProjectsService()

            'call routine to check for presence of string for filter prior to executing row filter
            'and causing a state change.
            Dim check = service.ProjectFilterResults(_projectDataset.Tables(0), textFilter, _projectsViewState)

            If check = False Then
                _statusChanged = False
            End If

            Select Case statusMode
                Case ViewState.Inactive
                    _projectBinding.Filter = "(ppm_project_active = 0) and ((ppm_project_name LIKE '%" & textFilter &
                                         "%' or ppm_project_number LIKE '%" & textFilter &
                                         "%' or ppm_status_desc LIKE '%" & textFilter & "%'))"

                Case ViewState.Active
                    _projectBinding.Filter = "(ppm_project_active = 1) and ((ppm_project_name LIKE '%" & textFilter &
                                         "%' or ppm_project_number LIKE '%" & textFilter &
                                         "%' or ppm_status_desc LIKE '%" & textFilter & "%'))"


                Case ViewState.All
                    _projectBinding.Filter = "(ppm_project_name LIKE '%" & textFilter & "%' or ppm_project_number LIKE '%" &
                                         textFilter & "%' or ppm_status_desc LIKE '%" & textFilter & "%')"
            End Select


            If Not textFilter = String.Empty Then
                projectfilterTextbox.BackColor = SystemColors.HotTrack
                projectfilterTextbox.ForeColor = SystemColors.HighlightText
            Else
                projectfilterTextbox.BackColor = SystemColors.Window
                projectfilterTextbox.ForeColor = SystemColors.ControlText
            End If

            Dim i As Integer = 1
        Catch ex As Exception

            Dim str As String = ex.Message

        End Try

    End Sub


    Private Sub cgdFund_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles cgdFund.MouseDown

        Try
            If e.Button = MouseButtons.Left And My.Computer.Keyboard.CtrlKeyDown = True Then
                Dim info As DataGridView.HitTestInfo = cgdFund.HitTest(e.X, e.Y)
                If info.RowIndex >= 0 Then
                    Dim view As DataRowView = cgdFund.Rows(info.RowIndex).DataBoundItem
                    If Not view Is Nothing Then
                        cgdFund.DoDragDrop(view, DragDropEffects.Copy)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub FundFormat(ByVal sender As Object, ByVal e As ConvertEventArgs)

        If e.DesiredType IsNot GetType(String) Or IsDBNull(e.Value) Then
            Exit Sub
        End If

        e.Value = CType(e.Value, Decimal).ToString("C")

    End Sub

    'format event
    Private Sub DateToFullDateString(sender As Object, cevent As ConvertEventArgs)

        If cevent.DesiredType IsNot GetType(String) Or IsDBNull(cevent.Value) Then
            Exit Sub
        End If

        cevent.Value = CType(cevent.Value, Date).ToString("MM/dd/yyyy")

    End Sub

    Private Sub DateStringToDate(sender As Object, cevent As ConvertEventArgs)

        If Not cevent.DesiredType Is GetType(Date) Then
            Return
        End If

        If cevent.Value.ToString() = "  /  /" Then cevent.Value = DBNull.Value

        Dim recordidInt As Integer
        Dim outDate As Date

        Dim gridRow As DataGridViewRow = cgdProject.Rows(cgdProject.CurrentRow.Index)
        'gets the Active datagridrow from cgdProject grid
        recordidInt = gridRow.Cells(0).Value

        Dim outVal = Date.TryParse(cevent.Value.ToString(), outDate)

        If outVal Then
            cevent.Value = Date.Parse(cevent.Value.ToString)
            'add modified recordid value to array list
            If Not _modifiedList.Contains(recordidInt) Then
                _modifiedList.Add(recordidInt)
                gridRow.Cells(44).Value = imlFunding.Images("Save")
                undoButton.Enabled = True
            End If
        Else



        End If

    End Sub

    Private Sub lnkEditType_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEditType.LinkClicked


        Dim te As New Model.ProjectType


    End Sub


    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles UserEditLink.LinkClicked

        Dim useredit As New ProjectUser
        useredit.Show()

    End Sub


    Private Sub ArcLink_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ArcLink.LinkClicked

        Dim arc As New FNSB.Publicworks.Projects.Reports.UI.ArchitectEngineer
        arc.Show()

    End Sub

    Private Sub ManagerLink_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ManagerLink.LinkClicked

        Dim mg = New FNSB.Publicworks.Projects.Reports.UI.ProjectManager
        mg.Show()

    End Sub

    Private Sub secretaryEditLink(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles secretaryEdit.LinkClicked

        Dim sec = New ProjectSecretary
        sec.Show()

    End Sub


    Private Sub lnkEditConsultant_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEditConsultant.LinkClicked

        Dim consultedit = New FNSB.Publicworks.Projects.Reports.UI.Consultant
        consultedit.Show()

    End Sub

    Private Sub lnkEditContractor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkEditContractor.LinkClicked

        Dim contractedit = New FNSB.Publicworks.Projects.Reports.UI.Contractor
        contractedit.Show()

    End Sub

    Private Sub ShowReport(ByRef report As SectionReport)

        If Not IsNothing(report) Then
            Dim reportViewer = New PWTrackingReporting.UI.ActiveReportViewer(report)
            reportViewer.Show()
        End If

    End Sub



    Private Sub ProjectReportLinkLinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles projectReportLink.LinkClicked

        Dim report = New ProjectUpdateForm()
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub

    Private Sub closedProjectsLink_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles closedProjectsLink.LinkClicked

        Dim dt As New PWTrackingReporting.Reports.UI.DateRangeDialog()
        dt.FormTitle = "Closed Projects Date Range"
        dt.ShowDialog()
        If dt.SelectionCancel Then Exit Sub

        Dim report = New ProjectsClosed(dt.StartDate, dt.EndDate)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub

    Private Sub WarrentyReportLinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles warrentyReport.LinkClicked


        Dim dt As New PWTrackingReporting.Reports.UI.DateRangeDialog()
        dt.FormTitle = "Correction Period Date Range"
        dt.ShowDialog()
        If dt.SelectionCancel Then Exit Sub

        Dim report = New ProjectWarrantyPeriod(dt.StartDate, dt.EndDate)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub


    Private Sub SubstantialCompletionLinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles substantialCompletionLink.LinkClicked

        Dim dt As New PWTrackingReporting.Reports.UI.DateRangeDialog()
        dt.FormTitle = "Substantial Completion Date Range"
        dt.ShowDialog()
        If dt.SelectionCancel Then Exit Sub


        Dim rp = New SubstantialCompleteActiveProjects(dt.StartDate, dt.EndDate)
        Dim report = New SubstantialCompleteActiveProjects(dt.StartDate, dt.EndDate)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub

    Private Sub EstimatedBidScheduleLinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles estimatedBidLink.LinkClicked


        Dim dt As New PWTrackingReporting.Reports.UI.DateRangeDialog()
        dt.FormTitle = "Est. Bid Schedule Date Range"
        dt.ShowDialog()
        If dt.SelectionCancel Then Exit Sub

        Dim report = New EstimatedBidSchedule(dt.StartDate, dt.EndDate)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub


    Private Sub orgkeyProjectReport_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles orgkeyProjectReport.LinkClicked

        Dim report = New Financials.FinancialReportByOrgKey()
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub

    Private Sub SecretaryProjectsReportLinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles secretaryProjectsReport.LinkClicked

        Dim ctx As New publicworksEntities
        Dim service = New SecretaryService(ctx)

        Dim entity = New EntityDynamicPrompt
        entity.StartPosition = FormStartPosition.CenterParent
        entity.FormTitle = "Select Secretary from Report"
        entity.EntitySelectDataSourceDictionary = service.GetActiveSecretariesDictionary().ToList()
        Dim result = entity.ShowDialog()

        If entity.SelectionCancel Or result = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim report = New ActiveProjectsSecretaryList(entity.EntityId)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub

    Private Sub managerProjectsReport_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles managerProjectsReport.LinkClicked

        Dim ctx As New publicworksEntities
        Dim service = New ProjectManagerService(ctx)
        Dim entity = New EntityDynamicPrompt
        entity.StartPosition = FormStartPosition.CenterParent
        entity.FormTitle = "Select Project Manager"
        entity.EntitySelectDataSourceDictionary = service.GetActiveProjectManagerDictionary().ToList()
        Dim result = entity.ShowDialog()

        If entity.SelectionCancel Or result = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim report = New ActiveProjectsManagerList(entity.EntityId)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub


    Private Sub ProjectManagerDetailReportLinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles managerDetailReportLink.LinkClicked

        Dim ctx As New publicworksEntities
        Dim service = New ProjectManagerService(ctx)
        Dim entity = New EntityDynamicPrompt
        entity.StartPosition = FormStartPosition.CenterParent
        entity.FormTitle = "Select Project Manager"
        entity.EntitySelectDataSourceDictionary = service.GetActiveProjectManagerDictionary().ToList()

        Dim result = entity.ShowDialog()
        If entity.SelectionCancel Or result = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim report = New ActiveProjectsManager(entity.EntityId)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub

    Private Sub ProjectArchitectDetailReport(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles projectArchitectDetailReportLink.LinkClicked

        Dim ctx As New publicworksEntities
        Dim service = New ArchitectEngineerService(ctx)
        Dim entity = New EntityDynamicPrompt
        entity.StartPosition = FormStartPosition.CenterParent
        entity.FormTitle = "Select Architect / Engineer"
        entity.EntitySelectDataSourceDictionary = service.GetActiveArchitectEngineerDictionary().ToList()
        entity.ShowDialog()
        If entity.SelectionCancel Then
            Exit Sub
        End If

        Dim report = New ActiveProjectsArchitect(entity.EntityId)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub

    Private Sub ProjectSecretaryDetailReport(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSecretaryDetail.LinkClicked

        Dim ctx As New publicworksEntities
        Dim service = New SecretaryService(ctx)
        Dim entity = New EntityDynamicPrompt
        entity.StartPosition = FormStartPosition.CenterParent
        entity.FormTitle = "Select Project Secretary"
        entity.EntitySelectDataSourceDictionary = service.GetActiveSecretariesDictionary().ToList()
        entity.ShowDialog()
        If entity.SelectionCancel Then
            Exit Sub
        End If

        Dim report = New ActiveProjectsSecretary(entity.EntityId)
        Cursor = Cursors.WaitCursor
        report.Run()
        Cursor = Cursors.Default
        ShowReport(report)

    End Sub




    Private Sub CapitalProjectsReportLinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles capitalProjectsReport.LinkClicked


        Dim reportSummaryManager = New FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects.StatusReportSummaryManager
        Cursor = Cursors.WaitCursor
        reportSummaryManager.Run()

        Dim reportSummaryType = New FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects.StatusReportSummaryProjectType
        reportSummaryType.Run()

        Dim capital = New FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects.ProjectStatusReport
        capital.Run()

        capital.Document.Pages.Insert(0, reportSummaryManager.Document.Pages(0))
        capital.Document.Pages.Insert(1, reportSummaryType.Document.Pages(0))


        Dim projectindex = New FNSB.Publicworks.Projects.Reporting.Reports.CapitalProjects.IndexByProject(capital.ProjectIndexList)
        projectindex.Run()

        capital.Document.Pages.AddRange(projectindex.Document.Pages)

        'For Each page In projectindex.Document.Pages
        '    capital.Document.Pages.Add()
        'Next

        Cursor = Cursors.Default
        ShowReport(capital)


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub buildStatusLabel_Click(sender As System.Object, e As System.EventArgs) Handles buildStatusLabel.Click

        Process.Start("\\Tundra2\Workgrps\FNSB-db\Update\TrackingDeploy\bugtracking.xlsm")

    End Sub

    Private Sub lblContractWarPeriod_Click(sender As Object, e As EventArgs) Handles lblContractWarPeriod.Click

    End Sub
End Class
