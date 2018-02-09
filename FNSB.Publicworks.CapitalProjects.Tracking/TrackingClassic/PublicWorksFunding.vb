Imports System
Imports System.Data
Imports C1.C1Schedule
Imports System.Configuration
Imports System.Data.Common
Imports FNSB_Facilities_Projects
Imports FNSB_Facilities_Projects.My.Resources
Imports System.Collections.Generic
Imports System.Globalization
Imports FNSB.Publicworks.Projects.DataLayer
Imports FNSB.Publicworks.Projects.DataLayer.Service
Imports FNSB.Publicworks.Projects.DataLayer.Model
Imports System.Data.SqlClient
Imports GrapeCity.ActiveReports.Export.Excel.Page
Imports System.Drawing.Text


Public Class PublicWorksFunding

    Private _importDataTable As DataTable
    Private _tempFundingTable As DataTable

    Private _fundBinding As New BindingSource
    Private _projectBinding As New BindingSource

    'Private Shared ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger _
    '                                          (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private _fundsModAL As New ArrayList
    Private _fundsRemAL As New ArrayList
    Private _fundsAddAL As New ArrayList
    Private _projectDataset As New DataSet
    Private _ProjectID As Integer
    Private _fundsManageAllMode As Boolean

    Sub New(projectDataset As DataSet, ProjectID As Integer)
        InitializeComponent()
        _projectDataset = projectDataset
        _ProjectID = ProjectID
    End Sub

    Private Sub PublicWorksFundingLoad(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try




            FundingModifyForm(_projectDataset, _ProjectID)
            SetupFundingGrid()  'data grid UI setup and control mods
            FundsEditModeSelection(_ProjectID)    'sets binding position from the passed project ID

            fundsundoButton.Enabled = False
            fundsaveButton.Enabled = False
            fundsdeleteButton.Enabled = False

            If Not _fundBinding.Count = 0 Then fundsdeleteButton.Enabled = True

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub FundsGridViewSelectionChanged(sender As System.Object, e As System.EventArgs) Handles fundsGridView.SelectionChanged

        fundsdeleteButton.Enabled = True


    End Sub

    Private Sub SetupFundingGrid()

        'Funds Grid Edit Mode
        With projectsDataGrid
            .MultiSelect = False    'single select mode
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect    'no single cell mode
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False 'block new from grid
            .AllowUserToDeleteRows = False  'block delete from grid
        End With

        With fundsGridView
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect    'no single cell mode
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
        End With

        Dim _fundgridCC
        _fundgridCC = fundsGridView.Columns()

        Dim md As DateTime
        md = "12/12/2001"

        _fundgridCC(0).Visible = True
        _fundgridCC(0).HeaderText = "Fund"
        _fundgridCC(0).Width = 40

        _fundgridCC(1).Visible = True
        _fundgridCC(1).HeaderText = "Dept"
        _fundgridCC(1).Width = 40

        _fundgridCC(2).Visible = True
        _fundgridCC(2).HeaderText = "Key"
        _fundgridCC(2).Width = 80

        _fundgridCC(3).Visible = True
        _fundgridCC(3).HeaderText = "Desc."
        _fundgridCC(3).Width = 270

        _fundgridCC(4).Visible = True
        _fundgridCC(4).HeaderText = "Budget"
        _fundgridCC(4).Width = 90
        _fundgridCC(4).DefaultCellStyle.Format = "$###,###,###,##0.00"
        _fundgridCC(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        _fundgridCC(6).Visible = True
        _fundgridCC(6).HeaderText = "Encumb."
        _fundgridCC(6).Width = 90
        _fundgridCC(6).DefaultCellStyle.Format = "$###,###,###,##0.00"
        _fundgridCC(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        _fundgridCC(5).Visible = True
        _fundgridCC(5).HeaderText = "Expend."
        _fundgridCC(5).Width = 90
        _fundgridCC(5).DefaultCellStyle.Format = "$###,###,###,##0.00"
        _fundgridCC(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        _fundgridCC(7).Visible = True
        _fundgridCC(7).HeaderText = "Balance"
        _fundgridCC(7).Width = 90
        _fundgridCC(7).DefaultCellStyle.Format = "$###,###,###,##0.00"
        _fundgridCC(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        _fundgridCC(8).Visible = False
        _fundgridCC(9).Visible = False

        Dim _projectgridCC As New DataGridViewColumnCollection(projectsDataGrid)
        _projectgridCC = projectsDataGrid.Columns()

        _projectgridCC(0).Visible = False
        _projectgridCC(1).Visible = False
        _projectgridCC(2).Visible = False
        _projectgridCC(6).Visible = False
        _projectgridCC(5).Visible = False
        _projectgridCC(7).Visible = False
        _projectgridCC(8).Visible = False

        _projectgridCC(2).Width = 150
        _projectgridCC(2).Visible = True
        _projectgridCC(2).HeaderText = "Project No."

        _projectgridCC(3).Width = 500
        _projectgridCC(3).Visible = True
        _projectgridCC(3).HeaderText = "Project Name"

        _projectgridCC(4).Width = 140
        _projectgridCC(4).Visible = True
        _projectgridCC(4).HeaderText = "Active Date"

        For j As Integer = 9 To 44
            _projectgridCC(j).Visible = False
        Next

    End Sub


    Private Sub ClearDataBindings()

        fundText.DataBindings.Clear()
        deptText.DataBindings.Clear()
        glkeyText.DataBindings.Clear()
        glnameText.DataBindings.Clear()
        budgetText.DataBindings.Clear()
        expendText.DataBindings.Clear()
        encumberText.DataBindings.Clear()
        balanceText.DataBindings.Clear()

    End Sub

    Private Sub SetEditBindings()

        ClearDataBindings()

        Dim fundBind = New Binding("Text", _fundBinding, "ppf_funding")
        AddHandler fundBind.Parse, AddressOf FundingRecordTextFieldChanged
        fundText.DataBindings.Add(fundBind)

        Dim deptBind = New Binding("Text", _fundBinding, "ppf_department")
        AddHandler deptBind.Parse, AddressOf DeptRecordTextFieldChanged
        deptText.DataBindings.Add(deptBind)

        Dim glkeyBind = New Binding("Text", _fundBinding, "ppf_glkey")
        AddHandler glkeyBind.Parse, AddressOf GlKeyRecordTextFieldChanged
        glkeyText.DataBindings.Add(glkeyBind)

        Dim glnameBind = New Binding("Text", _fundBinding, "ppf_glkey_name")
        AddHandler glnameBind.Parse, AddressOf GlKeyNameTextFieldChanged
        glnameText.DataBindings.Add(glnameBind)

        Dim budgetBind = New Binding("Text", _fundBinding, "ppf_budget")
        AddHandler budgetBind.Format, AddressOf TextboxDecimalFormat
        AddHandler budgetBind.Parse, AddressOf TextboxDecimalParse
        budgetText.DataBindings.Add(budgetBind)

        Dim expendBind = New Binding("Text", _fundBinding, "ppf_expenditures")
        AddHandler expendBind.Format, AddressOf TextboxDecimalFormat
        AddHandler expendBind.Parse, AddressOf TextboxDecimalParse
        expendText.DataBindings.Add(expendBind)

        Dim encumberBind = New Binding("Text", _fundBinding, "ppf_encumbrances")
        AddHandler encumberBind.Format, AddressOf TextboxDecimalFormat
        AddHandler encumberBind.Parse, AddressOf TextboxDecimalParse
        encumberText.DataBindings.Add(encumberBind)

        Dim balanceBind = New Binding("Text", _fundBinding, "ppf_balance")
        AddHandler balanceBind.Format, AddressOf TextboxDecimalFormat
        AddHandler balanceBind.Parse, AddressOf TextboxDecimalParse
        balanceText.DataBindings.Add(balanceBind)

    End Sub

    Private Sub DeptRecordTextFieldChanged(sender As System.Object, e As ConvertEventArgs)

        Dim m = e.Value
        Dim current As DataRowView = _fundBinding.Current

        If Not IsDBNull(current(1)) AndAlso Not m = current(1) Then
            _fundBinding.ResetBindings(False)
            fundsundoButton.Enabled = True
            fundsaveButton.Enabled = True
        End If

    End Sub

    Private Sub FundingRecordTextFieldChanged(sender As System.Object, e As ConvertEventArgs)

        Dim m = e.Value
        Dim current As DataRowView = _fundBinding.Current

        If Not IsDBNull(current(0)) AndAlso Not m = current(0) Then
            _fundBinding.ResetBindings(False)
            fundsundoButton.Enabled = True
            fundsaveButton.Enabled = True
        End If

    End Sub


    Private Sub GlKeyRecordTextFieldChanged(sender As System.Object, e As ConvertEventArgs)

        Dim m = e.Value
        Dim current As DataRowView = _fundBinding.Current

        If Not IsDBNull(current(2)) AndAlso Not m = current(2) Then
            _fundBinding.ResetBindings(False)
            fundsundoButton.Enabled = True
            fundsaveButton.Enabled = True
        End If

    End Sub


    Private Sub GlKeyNameTextFieldChanged(sender As System.Object, e As ConvertEventArgs)

        Dim m = e.Value
        Dim current As DataRowView = _fundBinding.Current

        If Not IsDBNull(current(3)) AndAlso Not m = current(3) Then
            _fundBinding.ResetBindings(False)
            fundsundoButton.Enabled = True
            fundsaveButton.Enabled = True
        End If

    End Sub
    Private Sub TextboxDecimalFormat(sender As System.Object, e As ConvertEventArgs)

        If e.DesiredType <> GetType(String) Then Exit Sub
        'If e.Value <> GetType(String) Then Exit Sub

        Dim value = Convert.ToString(e.Value)
        Try
            e.Value = Decimal.Parse(value).ToString("c")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TextboxDecimalParse(sender As System.Object, e As ConvertEventArgs)

        If Not e.DesiredType Is GetType(Decimal) Then Exit Sub

        Try

            e.Value = Decimal.Parse(e.Value.ToString(), NumberStyles.Currency, Nothing)
            Dim sourceRow As DataRowView = _fundBinding.Current

            'sourceRow.Item(7) = Convert.ToDecimal(budgetText.Text) - (Convert.ToDecimal(sourceRow.Item(5) + Convert.ToDecimal(sourceRow.Item(6))))
            'Dim balance = Convert.ToDecimal(budgetText.Text) - (Convert.ToDecimal(expendText.Text + Convert.ToDecimal(encumberText.Text)))
            'balanceText.Text = balance
            _fundBinding.EndEdit()
            '_fundBinding.ResetBindings(False)

        Catch ex As FormatException
            MessageBox.Show(CurrencyFormatErrorMessage, PrimaryDialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    ''' <summary>
    ''' Used to set the datasource to the funding data grid on the funding edit form
    ''' </summary>
    ''' <param name="id">'used to pass the current Active project into form to flow project</param>
    ''' <remarks>links to the funding datatable using a dataview so all changes are reflected on both forms </remarks>
    Public Sub FundingModifyForm(ByRef projectsDataSet As DataSet, Optional ByVal id As Integer = 0)

        Try
            'log.Info("setting funding datasource to the import data grid")

            'Import datatable set and DataSet Add
            If Not _projectDataset.Tables.Contains("import") Then
                _importDataTable = _projectDataset.Tables("funding").Clone() 'Clone funding table for import rows
                _importDataTable.TableName = "import"
                _projectDataset.Tables.Add(_importDataTable)
            End If

            '           dsMain.Tables["OrderDetails"].Columns["ItemTotal"].Expression =
            '"UnitPrice * Quantity * (1 - Discount)"

            projectsDataGrid.DataSource = _projectBinding
            fundsGridView.DataSource = _fundBinding

            'projects assign grid data source
            'projectNavigator.BindingSource = _projectBinding
            fundsNavigator.BindingSource = _fundBinding

            _projectBinding.DataSource = _projectDataset
            _projectBinding.DataMember = "projects"
            _projectBinding.Filter = "ppm_project_active = 1"
            _projectBinding.Sort = "ppm_active_date desc"

            _fundBinding.DataSource = _projectBinding
            _fundBinding.DataMember = "RelatedFunds"

            SetEditBindings()   'set form controls to the binding source


            AddHandler _fundBinding.ListChanged, AddressOf FundBindingChange  'enables control of the binding events

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub SetupFundingDataSources(ByRef projectsDataSet As DataSet, Optional ByVal id As Integer = 0)

        Try
            _fundBinding.DataSource = projectsDataSet.Tables(1)
            _fundBinding.ResetBindings(False)
            _fundBinding.MoveFirst()

            fundsGridView.DataSource = _fundBinding
            fundsNavigator.BindingSource = _fundBinding

            SetEditBindings()   'set form controls to the binding source

            AddHandler _fundBinding.ListChanged, AddressOf FundBindingChange  'enables control of the binding events

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'EventHandler for DataBound Control Changes to DataSource
    Private Sub FundBindingChange(ByVal sender As Object, ByVal cevent As System.ComponentModel.ListChangedEventArgs)


        ' log.Info("entering the FundBindingChange event")
        Dim prochangeType As Integer = cevent.ListChangedType

        'log.Info("checking the ListChangeType. Will exit if the prochangeType = 0. ListChangeType = " & prochangeType.ToString())

        If prochangeType = 0 Then
            'log.Info("prochangeType = 0. Exiting Sub")
            Exit Sub
        End If

        Try
            If prochangeType = ComponentModel.ListChangedType.ItemChanged Then  'CHANGED
                'log.Info("prochangeType = ItemChanged")
                'log.Info("creating new DataRowView (sourceRow) from _fundBinding.Current")
                Dim sourceRow As DataRowView = _fundBinding.Current
                'log.Info("calculating budget value for sourceRow object")
                sourceRow.Item(7) = Convert.ToDecimal(sourceRow.Item(4)) - (Convert.ToDecimal(sourceRow.Item(5) + Convert.ToDecimal(sourceRow.Item(6))))
                'log.Info("setting ResetBindings(False) on the _fundBinding BindingSource")
                _fundBinding.ResetBindings(False)
                fundsundoButton.Enabled = True
                fundsaveButton.Enabled = True

            ElseIf prochangeType = ComponentModel.ListChangedType.ItemDeleted Then
                'log.Info("prochangeType = ItemDeleted. Enable the funds undo and save command buttons")
                fundsundoButton.Enabled = True
                fundsaveButton.Enabled = True
            End If

        Catch ex As Exception
            ' log.Error("Excepetion in the FundBindingChange event. Exception Message: " & ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' sets the position of the binding source to the passed on ppm_record
    ''' </summary>
    ''' <param name="id">Project.Id</param>
    ''' <remarks></remarks>
    '''
    Private Sub FundsEditModeSelection(ByVal id As Integer)

        Try
            Dim i = _projectBinding.Find("ppm_recordid", id)    'find the position of the record in the source
            _projectBinding.Position = i    'set the position of the binding
            _projectBinding.ResetBindings(False)    'causes bound controls to redraw

        Catch ex As Exception

        End Try

    End Sub

    Private Function EditFundsSetup() As Integer

        Try

            'command check isActiveState
            'fundseditButton.Checked = True
            'AssignFundsButton.Checked = False
            'ImportFundsButton.Checked = False

            ImportFundsButton.BackColor = Color.FromKnownColor(KnownColor.ControlLight)
            ImportFundsButton.ForeColor = Color.FromKnownColor(KnownColor.ControlText)

            fundsaddButton.Enabled = True
            AssignFundsButton.Enabled = False
            fundsundoButton.Enabled = False
            fundsaveButton.Enabled = False

            'clears the import counters
            fundsnewTextbox.Text = 0
            fundsupdateTextbox.Text = 0

        Catch ex As Exception

        End Try

    End Function

    ''' <summary>
    ''' Creates a duplicate datatable to import new/updated funding records from the flat file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ImportFundsSetup()

        Try
            projectsDataGrid.MultiSelect = False    'one project to edit only
            fundsGridView.MultiSelect = True

            ImportFundsButton.Checked = True
            AssignFundsButton.Checked = False

            fundsaddButton.Enabled = False
            AssignFundsButton.Enabled = True
            fundsaveButton.Enabled = False
            fundsundoButton.Enabled = False

            ImportFundsButton.ForeColor = Color.DarkGreen

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Function ImportFundingFile() As Integer

        ImportFundingFile = -1  'Return default

        'file steam variables
        Dim selectFile As New OpenFileDialog
        Dim selectFileStream As IO.Stream
        selectFile.Filter = OpenFileDialogCsvFilter

        'String managers
        Dim importlineString As String()
        Dim fileString As New Text.StringBuilder
        Dim bImportFileCheck As Boolean         'File Check Boolean

        'Row count
        Dim newrecordsCounter As Integer = 0
        Dim updateRecs As Integer = 0
        Dim glString As String
        Dim glExistingIdList As List(Of String)

        Try

            'log4net log info entry
            ' log.Info("importing funding file")

            glExistingIdList = New List(Of String)

            'checking for edited funds prior to import so user can save edits/adds/deletes
            'log.Info("begin check for fund record modifications")
            If CheckFundRecordsForModifications() = True Then
                Dim removeDialog = MessageBox.Show(SaveFundsBeforeImport, PrimaryDialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If removeDialog = Windows.Forms.DialogResult.Yes Then
                    Dim pubworks As New Publicworks
                    Dim i = pubworks.PublicWorksFundingUpdate(_projectDataset.Tables("funding"))
                    If Not i = 0 Then Throw New Exception("Error updating funding prior to ImportFundsSetup")
                Else : Exit Function
                End If
            End If

            '*** FILE STREAM ****
            'Present the file selection box to load select/import file
            If selectFile.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Cursor.Current = Cursors.WaitCursor
                Dim fileCheck As Boolean = selectFile.CheckFileExists() 'verify file exists

                If fileCheck = True Then  'file exists

                    ImportFundsSetup()  'setup the grid and control buttons

                    ' log.Info("opening import file")
                    selectFileStream = selectFile.OpenFile()  'open file to begin processing
                    Dim streamread As System.IO.StreamReader  'Create new stream reader objects for iterating through files
                    'log.Info("creating StreamReader object")
                    streamread = New System.IO.StreamReader(selectFileStream)

                    Dim filter As New Service.GlkeyImportManager(Resources.GlkeyAcceptionsFile)

                    'counter variables
                    Dim r As Integer = 1
                    Dim i As Integer

                    'File parse code setup - easy read CSV
                    Dim fileparse As FileIO.TextFieldParser = New FileIO.TextFieldParser(selectFileStream)
                    Dim CurrentRecord As String()
                    fileparse.TextFieldType = FileIO.FieldType.Delimited
                    fileparse.Delimiters = New String() {","}
                    fileparse.HasFieldsEnclosedInQuotes = False

                    'Acculators for Funding Import Monetary values
                    Dim budgetDec, encumbDec, expendDec, availDec As Decimal

                    _fundBinding.RaiseListChangedEvents = False

                    ' log.Info("begin stream read loop")

                    Do While Not fileparse.EndOfData

                        CurrentRecord = fileparse.ReadFields()
                        glString = CurrentRecord(2)

                        Dim queryimportDataRow() As DataRow    'Row used to query existing data to check for existing records
                        queryimportDataRow = _projectDataset.Tables("funding").Select("ppf_glkey = '" & glString & "'")

                        Select Case queryimportDataRow.Length
                            Case 0   'FUND RECORD DOES NOT EXIST CURRENTLY
                                'Dim fundsimportDataRow As DataRow = _fundsimportTable.NewRow()
                                'fundsimportDataRow.BeginEdit()

                                Dim importNewRow As DataRow = _projectDataset.Tables("import").NewRow()

                                importNewRow.Item(0) = CurrentRecord(0) 'fund
                                importNewRow.Item(1) = CurrentRecord(1) 'dept
                                importNewRow.Item(2) = CurrentRecord(2) 'glkey
                                importNewRow.Item(3) = CurrentRecord(3) 'glkey name

                                If Decimal.TryParse(CurrentRecord(4), budgetDec) = True Then    'validate as decimal
                                    budgetDec = CDec(CurrentRecord(4))
                                    importNewRow.Item(4) = budgetDec   'budget
                                End If

                                If Decimal.TryParse(CurrentRecord(5), expendDec) = True Then  'validate as decimal
                                    expendDec = CDec(CurrentRecord(5))
                                    importNewRow.Item(5) = expendDec   'encumbrances
                                End If

                                If Decimal.TryParse(CurrentRecord(6), encumbDec) = True Then  'validate as decimal
                                    encumbDec = CDec(CurrentRecord(6))
                                    importNewRow.Item(6) = encumbDec  'expenditures
                                    'calculate balance
                                    availDec = budgetDec - (encumbDec + expendDec)   'calc the available balance
                                    importNewRow.Item(7) = availDec  'plug bal in ppi_available_balance column
                                End If

                                importNewRow.Item(8) = 0
                                importNewRow.EndEdit()

                                _projectDataset.Tables("import").Rows.Add(importNewRow)
                                newrecordsCounter += 1

                            Case Is >= 1  'FUND RECORD DOES EXIST

                                queryimportDataRow(0).Item(0) = CurrentRecord(0) '
                                queryimportDataRow(0).Item(1) = CurrentRecord(1) '
                                queryimportDataRow(0).Item(2) = CurrentRecord(2) '
                                queryimportDataRow(0).Item(3) = CurrentRecord(3) '

                                If Decimal.TryParse(CurrentRecord(4), budgetDec) = True Then    'validate as decimal
                                    budgetDec = CDec(CurrentRecord(4))
                                    queryimportDataRow(0).Item(4) = budgetDec   'budget
                                End If

                                If Decimal.TryParse(CurrentRecord(5), expendDec) = True Then  'validate as decimal
                                    expendDec = CDec(CurrentRecord(5))
                                    queryimportDataRow(0).Item(5) = expendDec   'encumbrances
                                End If

                                If Decimal.TryParse(CurrentRecord(6), encumbDec) = True Then  'validate as decimal
                                    encumbDec = CDec(CurrentRecord(6))
                                    queryimportDataRow(0).Item(6) = encumbDec  'expenditures
                                    availDec = budgetDec - (encumbDec + expendDec)   'calc the available balance
                                    queryimportDataRow(0).Item(7) = availDec  'plug bal in ppi_available_balance column
                                    'Issue with modified records not updating the RowState
                                    If (queryimportDataRow(0).RowState = DataRowState.Unchanged) Then queryimportDataRow(0).SetModified()
                                End If

                                glExistingIdList.Add(glString)
                                updateRecs += 1

                            Case Else
                                MessageBox.Show("Error occurred during funding import")
                                Exit Select
                        End Select
                    Loop    'end loop that interates the file and generates/updates the datatables/rows


                    ' log.Info("End stream read loop")

                    Cursor.Current = Cursors.Default

                    Try

                        Dim importmodifiedDataTable As DataTable = _projectDataset.Tables("funding").GetChanges(DataRowState.Modified)
                        ' log.Info("new datatable created from modified funding records in the stream loop")

                        If Not IsNothing(importmodifiedDataTable) Then    'check that records exist
                            'log.Info("modified funding records exist")
                            'save the modified funding records

                            'TODO show an import report
                            Dim publicworks As New Publicworks

                            Dim checkupdate As Integer = publicworks.PublicWorksFundingUpdate(_projectDataset.Tables("funding"))    'updates the funding datatable updated in the above loop

                            _fundBinding.RaiseListChangedEvents = True

                            If Not updateRecs = checkupdate Then
                                For Each row As DataRow In importmodifiedDataTable.Rows
                                    Dim key = row("ppf_glkey")
                                    Dim result = glExistingIdList.Contains(key.ToString().Trim())
                                    If result = True Then
                                        glExistingIdList.Remove(key)
                                    End If
                                Next
                            End If

                            'TODO make a quick form to show stats @ ActiveReports6 here
                            'displays the update number of records to the user
                            fundsGridView.ClearSelection()
                        End If

                        'Check for rows in the new funds datatable display new funds in the grid
                        If _projectDataset.Tables("import").Rows.Count > 0 Then
                            _fundBinding.DataSource = _projectDataset.Tables("import")
                            '_fundsGridView.DataSource = _projectDataset.Tables("import")
                        Else
                            '    'mode to edit
                        End If 'set the fund grid to added rows

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        'log.Error("Exception thrown during import")
                    End Try
                End If

               ' log.Info("updating the stats checkboxes with update and new record counts")
                'display the new/update stats to the users
                fundsupdateTextbox.Text = updateRecs.ToString
                fundsnewTextbox.Text = newrecordsCounter.ToString   'TODO make dynamic

            ElseIf Windows.Forms.DialogResult.Cancel Then
                'log.Info("user cancelled import")
                'log.Info("setting ImportFundsButton the Checkstate.Unchecked")
                ImportFundsButton.CheckState = CheckState.Unchecked
                'log.Info("reset form to edit using EditFundsSetup method")
                EditFundsSetup()

            End If

            ImportFundingFile = 0

        Catch ex As Exception
            MsgBox(ex.Message)

            Exit Function
        Finally

        End Try

    End Function


    Private Sub FundsimportButtonCheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportFundsButton.Click

        Try

            If _fundsManageAllMode = True Then

                If AllActiveFundingRecordsToolStripMenuItem.Checked = True Then
                    AllActiveFundingRecordsToolStripMenuItem.Checked = False
                End If

                If InactiveFundingRecordsAllToolStripMenuItem.Checked = True Then
                    InactiveFundingRecordsAllToolStripMenuItem.Checked = False
                End If

                'ResetDefaultFundBindings()
            End If


            If ImportFundsButton.CheckState = CheckState.Checked Then   'IMPORT

                Dim importInt = ImportFundingFile()

            ElseIf ImportFundsButton.CheckState = CheckState.Unchecked Then 'EDIT
                'prompt user if imports still exist  before proceed to edit
                If Not _projectDataset.Tables("import").Rows.Count = 0 Then
                    'message states going to edit will require reimporting  funds to get them assigned
                    Dim dialog = MessageBox.Show(FundingImportUnassigned, PrimaryDialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If dialog = DialogResult.No Then    'user stays in import
                        ImportFundsButton.Checked = True
                        Exit Sub
                    End If
                End If

                'user wants to exit import - remove import table - change grid binding back to parent/child binding source relationship 
                '   and reset the form controls using EditFundsSetup()
                _projectDataset.Tables("import").Clear()

                _fundBinding = Nothing
                _fundsGridView.DataSource = Nothing
                _fundsNavigator.BindingSource = Nothing

                _fundBinding = New BindingSource()
                _fundsGridView.DataSource = _fundBinding
                _fundsNavigator.BindingSource = _fundBinding

                _fundBinding.DataSource = _projectBinding
                _fundBinding.DataMember = "RelatedFunds"

                AddHandler _fundBinding.ListChanged, AddressOf FundBindingChange  'enables control of the binding events

                ClearDataBindings()
                SetEditBindings()

                FundsEditModeSelection(_ProjectID)    'takes the current project from parent and sets the fund manager form to edit it
                SetupFundingGrid()
                EditFundsSetup()

            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Checks the funding Dataview for changes and prompts the user with a save option
    ''' </summary>
    ''' <remarks>Looks for adds, deletes and modifies</remarks>
    Private Function CheckFundRecordsForModifications() As Boolean

        Try
            If IsNothing(_projectDataset.Tables("funding").GetChanges(DataRowState.Modified)) Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function


    Private Sub FundsassignButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignFundsButton.Click

        Try
            'log.Info()
            Select Case True
                Case ImportFundsButton.Checked = True 'IMPORT MODE ON
                    If Not _ProjectID = 0I Then

                        Dim rowCollection As DataGridViewSelectedRowCollection = fundsGridView.SelectedRows()  'collection of the gridview rows selected
                        If Not rowCollection.Count = 0 Then    'move forward if collection contains records

                            Dim importList As New List(Of Integer)  'used the iterate the datagridview row collection and store the recordid in cell 9
                            Dim rows As DataRow()
                            For Each row As DataGridViewRow In rowCollection   'loop to tag the ppm_recordid with the currently selected project's recordid
                                importList.Add(row.Cells(9).Value)   'snags the selected imported row(s) recordid's and caches them for lookup in the datatable  
                            Next

                            For Each item In importList  'iterate the ID data array performing and table find to process row by updating the ppm_recordid with the project ID to assign
                                Dim dataRow As DataRow = _projectDataset.Tables("import").Rows.Find(item)  'find row with ppi_recordid
                                If Not dataRow Is Nothing Then  'verify exists
                                    _fundBinding.RaiseListChangedEvents = False
                                    dataRow.BeginEdit()     'prevents events from firing
                                    dataRow.Item(8) = projectsDataGrid.CurrentRow.Cells(0).Value   'assigns the selected projects recordid
                                    dataRow.EndEdit()   'enables event triggers
                                    _projectDataset.Tables("funding").ImportRow(dataRow)
                                    _projectDataset.Tables("import").Rows.Remove(dataRow)
                                    _fundBinding.RaiseListChangedEvents = True
                                    _fundBinding.ResetBindings(False)

                                End If
                            Next

                            Dim pwfundingsave As New Publicworks    'new publicworks class to save the assigned datarows
                            Dim j = pwfundingsave.PublicWorksFundingUpdate(_projectDataset.Tables("funding"))

                            If Not importList.Count = j Then
                                Throw New Exception("Saving the assigned import record has failed")
                            End If

                            fundsnewTextbox.Text = _projectDataset.Tables("import").Rows.Count  'update the counter for new imports

                        End If
                    End If

                Case AssignFundsButton.Checked = True 'ASSIGN

                    Dim removeDialog As New DialogResult
                    removeDialog = MessageBox.Show(BudgetAlterStatement, _
                                                   PublicworksProjectHeader, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                    If removeDialog = Windows.Forms.DialogResult.OK Then
                        Dim fundsRowView As DataRowView = _fundBinding.Current  'binding current position - extract rowview
                        fundsRowView.BeginEdit()
                        fundsRowView.Item("ppm_recordid") = DBNull.Value    'wipes the project recordid 
                        fundsRowView.EndEdit()
                        _fundsRemAL.Add(fundsRowView.Item("ppf_recordid"))  'add the rowview item to an arraylist
                    Else : Exit Sub
                    End If

                Case ImportFundsButton.Checked = False   'EDIT MODE - ASSIGN fund to selected Project

                    'dialog throw to ensure user wants to take a funding source from an inactive project and reassign it
                    If InactiveFundingRecordsAllToolStripMenuItem.Checked Then
                        Dim activateDialog
                        activateDialog = MessageBox.Show(InactiveFundingRecordAssignment, _
                                                       PublicworksProjectHeader, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

                        'User cancelled operation - Exit the sub
                        If activateDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                    End If

                    'dialog throw to ensure user wants to take a funding source from an active project and reassign it
                    If AllActiveFundingRecordsToolStripMenuItem.Checked Then
                        Dim activateDialog
                        activateDialog = MessageBox.Show(ActiveFundingRecordAssignment, _
                                                       PublicworksProjectHeader, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        'User cancelled operation - Exit the sub
                        If activateDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

                    End If

                    'Gets the current project row from the binding source (used for update of the funding record)
                    Dim projectView As DataRowView = _projectBinding.Current
                    Dim fundView As DataRowView = _fundBinding.Current

                    _fundBinding.RaiseListChangedEvents = False
                    _fundBinding.SuspendBinding()

                    fundView.BeginEdit()
                    'select the funding table row using the view ppf_recordid id field
                    Dim ur = _projectDataset.Tables(1).Rows.Find(fundView.Row.Item(9))

                    'Assign value of the ppm_recordid to the funding record ppm_recordid child field
                    ur.Item("ppm_recordid") = projectView.Item(0)
                    fundView.EndEdit()

                    'new publicworks class to save the assigned datarow
                    Dim pwfundingsave As New Publicworks
                    Dim j = pwfundingsave.PublicWorksFundingUpdate(_projectDataset.Tables("funding"))

                    _fundBinding.ResumeBinding()
                    _fundBinding.RaiseListChangedEvents = True

            End Select

        Catch ex As Exception

        End Try

    End Sub


    Public Sub BudgetItemsTextLeave()

        Try
            'Loads the current values into an array before calculations
            Dim fundvaluepreDataRowView As DataRowView
            Dim fundsrecidInteger As Integer

            fundvaluepreDataRowView = _fundBinding.Current
            fundsrecidInteger = fundvaluepreDataRowView("ppf_recordid")

            Dim fundbalancepreArray() As Decimal = New Decimal(3) {fundvaluepreDataRowView.Item("ppf_budget"), fundvaluepreDataRowView.Item("ppf_expenditures"), _
                                                                   fundvaluepreDataRowView.Item("ppf_encumbrances"), fundvaluepreDataRowView.Item("ppf_balance")}

            ' _fundBinding.EndEdit()  'forces the list to update with the update items entered

            Dim fundvalueDataRowView As DataRowView 'Loads the current values into an array after the the EndEdit updates the 
            fundvalueDataRowView = _fundBinding.Current
            Dim fundsbudgetitemsDataRow As DataRow = _projectDataset.Tables("funding").Rows.Find(fundvalueDataRowView.Item("ppf_recordid"))

            If Not fundsbudgetitemsDataRow Is Nothing Then
                With fundsbudgetitemsDataRow
                    Dim fundbalanceDecArray() As Decimal = New Decimal(3) {.Item("ppf_budget"), .Item("ppf_expenditures"), .Item("ppf_encumbrances"), .Item("ppf_balance")}
                    'calculates the budget for the entered expends and encumbs if changes detected in current list values for thise 
                    If Not fundbalancepreArray(0) = fundbalanceDecArray(0) Or Not fundbalancepreArray(1) = fundbalanceDecArray(1) Or Not fundbalancepreArray(2) = fundbalanceDecArray(2) Then
                        fundbalanceDecArray(3) = fundbalanceDecArray(0) - (fundbalanceDecArray(1) + fundbalanceDecArray(2))
                        .BeginEdit()
                        .Item("ppf_budget") = fundbalanceDecArray(0)
                        .Item("ppf_expenditures") = fundbalanceDecArray(1)
                        .Item("ppf_encumbrances") = fundbalanceDecArray(2)
                        .Item("ppf_balance") = fundbalanceDecArray(3)
                        .EndEdit()
                        _fundBinding.EndEdit()  'forces the list to update with the update items entered
                        balanceText.Text = String.Format("{0:C2}", fundbalanceDecArray(3))  'display the balance text
                    End If
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub AddfundsButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fundsaddButton.Click

        Try

            Dim fundDataRow As DataRow = _projectDataset.Tables("funding").NewRow() ' new row generated from the datatable
            Dim fundidInteger As Integer = CInt(fundDataRow.Item(9))    'get the ppI-recordid from the new row (table is constrained)

            If _fundsAddAL.Count > 0 Then   'funds added prior to save

                Dim confirmaddDialog As New DialogResult    'prompt user for action on added but unsaved record
                confirmaddDialog = MsgBox("A new funding record has been added to this project and has not been saved. " & _
                                          "Select OK to save this new record and continue adding funds or Cancel to " & _
                                          "return to the unsaved record.", MsgBoxStyle.OkCancel, PublicworksProjectHeader)
                Select Case confirmaddDialog
                    Case Windows.Forms.DialogResult.OK  'user has confirmed saving added record prior to adding additional funds
                        Dim pubworks As New Publicworks     'new class to save records
                        Dim returnupdateInt = pubworks.PublicWorksFundingUpdate(_projectDataset.Tables(0).GetChanges(DataRowState.Added)) 'execute update and the added record
                        If returnupdateInt = 0 Then
                            _projectDataset.Tables("funding").AcceptChanges()

                            _fundBinding.ResetBindings(False)   'updates the controls bound to the bindingsource
                            _fundsAddAL.Clear() 'clears the arraylist holding funding recordid
                            pubworks = Nothing

                        End If
                    Case Windows.Forms.DialogResult.Cancel  'User elects to return to added but unsaved record
                        Dim fundsaddid As Integer = _fundsAddAL.Item(0) 'scoops the ppi_recordid to find it in the binding source
                        Dim fundsaddindex As Integer = _fundBinding.Find("ppf_recordid", fundsaddid)    'perform the find on the bind source
                        _fundBinding.Position = fundsaddindex   'set the position in the binding source
                        Exit Sub
                End Select
            End If

            _fundsAddAL.Add(fundidInteger)  'keeps list of keys to keep users from overadding.

            If ImportFundsButton.Checked = False And Not _ProjectID = 0 Then    'keep fund adds to projects in edit mode
                fundDataRow.Item("ppf_glkey_name") = "New funds for: " & projectsDataGrid.CurrentRow.Cells(3).Value
                fundDataRow.Item("ppm_recordid") = projectsDataGrid.CurrentRow.Cells(0).Value   'inserts the ppm_recordid (project's ID) into the funding record
                'fundDataRow.Item("PPR_Recordid") = 0
            End If

            _projectDataset.Tables("funding").Rows.Add(fundDataRow) 'adds the new datarow back to the table eith 
            Dim fundbindindexInteger = _fundBinding.Find("ppf_recordid", fundidInteger) 'sets the current row to the newly added funding recordid
            _fundBinding.Position = fundbindindexInteger    'sets the position
            fundsGridView.SelectedRows(0).Selected = True   'select the row in he funds grid

            _fundBinding.ResetBindings(False)   'updates the controls bound to the bindingsource
            Me.fundsundoButton.Enabled = True
            Me.fundsaveButton.Enabled = True
            fundsdeleteButton.Enabled = True

        Catch ex As Exception

        End Try

    End Sub


    Private Sub FundDeleteButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fundsdeleteButton.Click

        Try

            If ImportFundsButton.Checked = True Then

                Dim removeimportDialog = MessageBox.Show(ConfirmDeleteImportNotSaved, PrimaryDialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If removeimportDialog = DialogResult.No Then Exit Sub
                Dim rowCollection As DataGridViewSelectedRowCollection = fundsGridView.SelectedRows()

                If Not rowCollection.Count = 0 Then

                    Dim importList As New List(Of Integer)
                    Dim rows As DataRow()

                    For Each row As DataGridViewRow In rowCollection
                        importList.Add(row.Cells(9).Value)
                    Next

                    For Each item In importList
                        Dim dataRow As DataRow = _projectDataset.Tables("import").Rows.Find(item)
                        If Not dataRow Is Nothing Then
                            _fundBinding.RaiseListChangedEvents = False
                            dataRow.BeginEdit()
                            dataRow.Delete()
                            dataRow.EndEdit()
                            _fundBinding.RaiseListChangedEvents = True
                            _fundBinding.ResetBindings(False)
                        End If
                    Next

                    fundsnewTextbox.Text = _projectDataset.Tables("import").Rows.Count

                End If

                Exit Sub

            End If

            Dim removeDialog = MessageBox.Show(ConfirmDelete, PrimaryDialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If removeDialog = DialogResult.No Then Exit Sub

            Dim fundDataRowView As DataRowView = _fundBinding.Current 'DataRowView extracted from from the binding object
            Dim fundrecidInt As Integer = fundDataRowView.Item("ppf_recordid")  'get current Funds.id from the datarowview

            If _projectDataset.Tables("funding").Rows.Contains(fundrecidInt) Then 'verify existence in the datatable

                Dim funddelDatRow As DataRow = _projectDataset.Tables("funding").Rows.Find(fundrecidInt)
                funddelDatRow.Delete()
                funddelDatRow.AcceptChanges()

                Dim pubworks As New Publicworks
                Dim i = pubworks.FundingRowsDelete(fundrecidInt)
                If Not i = 0 Then Throw New Exception("Error updating funding prior to ImportFundsSetup")
                _projectDataset.Tables("funding").AcceptChanges()

                fundsGridView.ClearSelection()
                fundsundoButton.Enabled = False
                fundsaveButton.Enabled = False
                fundsdeleteButton.Enabled = False
                pubworks = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub SaveButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles fundsaveButton.Click

        Try

            Dim pworks As New Publicworks
            Dim i = pworks.PublicWorksFundingUpdate(_projectDataset.Tables("funding"))  'saves all pending changes to the funds datatables

            fundsaveButton.Enabled = False
            fundsundoButton.Enabled = False
            fundsdeleteButton.Enabled = False

            _fundsModAL.Clear()
            _fundsAddAL.Clear()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FundsundoButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fundsundoButton.Click

        Try

            _fundsAddAL.Clear()
            _fundsModAL.Clear()
            'reject all changes/adds to the funding table
            _projectDataset.Tables("funding").RejectChanges()
            _fundBinding.ResetBindings(False)
            fundsundoButton.Enabled = False
            fundsaveButton.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub ProjectsearchTextboxKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles projectsearchTextbox.KeyUp

        Try

            Dim textFilter As String = projectsearchTextbox.Text
            _projectBinding.Filter = "(ppm_project_active = 1) and ((ppm_project_name LIKE '%" & textFilter & "%' or ppm_project_number LIKE '%" & textFilter & "%'))"

            If Not textFilter = String.Empty Then
                projectsearchTextbox.BackColor = SystemColors.HotTrack
                projectsearchTextbox.ForeColor = SystemColors.HighlightText
            Else
                projectsearchTextbox.BackColor = SystemColors.Window
                projectsearchTextbox.ForeColor = SystemColors.ControlText
            End If

            Dim i As Integer = 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub AllActiveFundingRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllActiveFundingRecordsToolStripMenuItem.Click

        'loading all funding in import mode is not allowed
        If ImportFundsButton.Checked = False Then
            If InactiveFundingRecordsAllToolStripMenuItem.Checked Then
                'Check the Active Funding Menu Item
                InactiveFundingRecordsAllToolStripMenuItem.Checked = False
            End If

            'Load all funding scenario when the Active Funding Menu item is checked
            If AllActiveFundingRecordsToolStripMenuItem.Checked Then
                LoadFundingTableWithAllFundingRecords(True) 'boolean param for active projects funding load
            Else
                ResetDefaultFundBindings()  'restores the binding sources to the project/funding dataset relation
            End If
        End If

    End Sub

    Private Sub InactiveFundingRecordsAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InactiveFundingRecordsAllToolStripMenuItem.Click

        'loading all funding in import mode is not allowed
        If ImportFundsButton.Checked = False Then
            If AllActiveFundingRecordsToolStripMenuItem.Checked Then
                'Uncheck the Active Funding Menu Item
                AllActiveFundingRecordsToolStripMenuItem.Checked = False
            End If

            'Load all funding scenario when the Inactive Funding Menu item is checked
            If InactiveFundingRecordsAllToolStripMenuItem.Checked Then
                LoadFundingTableWithAllFundingRecords(False)    'boolean param for active projects funding load
            Else
                ResetDefaultFundBindings()  'restores the binding sources to the project/funding dataset relation
            End If
        End If

    End Sub

    ''' <summary>
    ''' Method used to setup the funding datatable to again relate to project data using the dataset relation object
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetDefaultFundBindings()

        ClearDataBindings()
        _projectDataset.Tables(1).Clear()

        _projectDataset.Tables(1).BeginLoadData()

        Dim pwq = New Publicworks()
        Dim dbFundDataTable = pwq.PublicWorksLoadFunding()

        For Each item As DataRow In dbFundDataTable.Rows
            _projectDataset.Tables(1).ImportRow(item)
        Next

        _projectDataset.Tables(1).EndLoadData()

        _fundBinding.DataSource = _projectBinding
        _fundBinding.DataMember = "RelatedFunds"
        SetupFundingGrid()
        SetEditBindings()

        _fundsManageAllMode = False
        AssignFundsButton.Enabled = False

    End Sub


    Private Sub LoadFundingTableWithAllFundingRecords(isActiveState As Boolean)

        'takes the existing data from the funding DT and stores Copy prior to switching to Active/Inactive funding all display
        Dim projectCon As New SqlConnection
        Dim selectCmd As New SqlCommand
        Dim pReader As SqlDataReader
        Const pwc As String = "PWD"   'SQL Connection string from app.config 
        Dim cn = ConfigurationManager.ConnectionStrings(pwc)

        'connection data
        projectCon.ConnectionString = cn.ConnectionString
        selectCmd.Connection = projectCon

        'select the stored procedure to execute based on the project status selection
        If (isActiveState) Then
            selectCmd.CommandText = "Publicworks.usp_select_all_active_funding"
        Else
            selectCmd.CommandText = "Publicworks.usp_select_all_inactive_funding"
        End If

        'command meta and connection open
        selectCmd.CommandType = CommandType.StoredProcedure
        projectCon.Open()
        'fire query as SqlReader
        pReader = selectCmd.ExecuteReader(CommandBehavior.CloseConnection)

        'keeps binding from going crazy
        _fundBinding.RaiseListChangedEvents = False

        'blanks the datatable to repopulate with query data - same schema
        _projectDataset.Tables(1).Clear()
        _projectDataset.Tables(1).BeginLoadData()

        'iterate the reader to load table
        Do While pReader.Read()
            _projectDataset.Tables(1).Rows.Add(pReader(1), pReader(2), pReader(3), pReader(4), pReader(5), _
                                               pReader(6), pReader(7), pReader(8), pReader(9), pReader(0))
        Loop

        _projectDataset.Tables(1).EndLoadData()

        'commits the updated records to the datatable
        _projectDataset.Tables("funding").AcceptChanges()

        _fundBinding.RaiseListChangedEvents = True


        'reset the bindings on the form items and batabinding objects
        SetupFundingDataSources(_projectDataset)

        _fundsManageAllMode = True
        AssignFundsButton.Enabled = True

    End Sub


End Class