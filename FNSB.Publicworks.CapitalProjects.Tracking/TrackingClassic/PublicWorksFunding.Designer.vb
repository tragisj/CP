<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PublicWorksFunding
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PublicWorksFunding))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fundsGridView = New System.Windows.Forms.DataGridView()
        Me.balanceLabel = New System.Windows.Forms.Label()
        Me.balanceText = New System.Windows.Forms.TextBox()
        Me.deptLabel = New System.Windows.Forms.Label()
        Me.fundLabel = New System.Windows.Forms.Label()
        Me.encumbLabel = New System.Windows.Forms.Label()
        Me.expendLabel = New System.Windows.Forms.Label()
        Me.budgetLabel = New System.Windows.Forms.Label()
        Me.glkeynameLabel = New System.Windows.Forms.Label()
        Me.glkeyLabel = New System.Windows.Forms.Label()
        Me.deptText = New System.Windows.Forms.TextBox()
        Me.encumberText = New System.Windows.Forms.TextBox()
        Me.expendText = New System.Windows.Forms.TextBox()
        Me.budgetText = New System.Windows.Forms.TextBox()
        Me.fundText = New System.Windows.Forms.TextBox()
        Me.glnameText = New System.Windows.Forms.TextBox()
        Me.glkeyText = New System.Windows.Forms.TextBox()
        Me.fundsNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.fundsaddButton = New System.Windows.Forms.ToolStripButton()
        Me.fundsdeleteButton = New System.Windows.Forms.ToolStripButton()
        Me.fundsundoButton = New System.Windows.Forms.ToolStripButton()
        Me.fundsaveButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFundingManageAll = New System.Windows.Forms.ToolStripSplitButton()
        Me.AllActiveFundingRecordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InactiveFundingRecordsAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.AssignFundsButton = New System.Windows.Forms.ToolStripButton()
        Me.ImportFundsButton = New System.Windows.Forms.ToolStripButton()
        Me.fundsnewLabel = New System.Windows.Forms.ToolStripLabel()
        Me.fundsnewTextbox = New System.Windows.Forms.ToolStripTextBox()
        Me.fundsupdateLabel = New System.Windows.Forms.ToolStripLabel()
        Me.fundsupdateTextbox = New System.Windows.Forms.ToolStripTextBox()
        Me.fundsimpacceptionsDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.fundsactionToolStrip = New System.Windows.Forms.ToolStrip()
        Me.projectsearchTextbox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.projectsDataGrid = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.fundsGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fundsNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fundsNavigator.SuspendLayout()
        Me.fundsactionToolStrip.SuspendLayout()
        CType(Me.projectsDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fundsGridView
        '
        Me.fundsGridView.AllowDrop = True
        Me.fundsGridView.AllowUserToAddRows = False
        Me.fundsGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        Me.fundsGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.fundsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fundsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.MediumSeaGreen
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.fundsGridView.DefaultCellStyle = DataGridViewCellStyle11
        Me.fundsGridView.Location = New System.Drawing.Point(12, 251)
        Me.fundsGridView.MultiSelect = False
        Me.fundsGridView.Name = "fundsGridView"
        Me.fundsGridView.ReadOnly = True
        Me.fundsGridView.RowTemplate.Height = 24
        Me.fundsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.fundsGridView.Size = New System.Drawing.Size(852, 160)
        Me.fundsGridView.TabIndex = 454
        '
        'balanceLabel
        '
        Me.balanceLabel.AutoSize = True
        Me.balanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.balanceLabel.Location = New System.Drawing.Point(552, 558)
        Me.balanceLabel.Name = "balanceLabel"
        Me.balanceLabel.Size = New System.Drawing.Size(52, 15)
        Me.balanceLabel.TabIndex = 493
        Me.balanceLabel.Text = "Balance"
        '
        'balanceText
        '
        Me.balanceText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.balanceText.Location = New System.Drawing.Point(647, 554)
        Me.balanceText.Name = "balanceText"
        Me.balanceText.ReadOnly = True
        Me.balanceText.Size = New System.Drawing.Size(167, 22)
        Me.balanceText.TabIndex = 485
        '
        'deptLabel
        '
        Me.deptLabel.AutoSize = True
        Me.deptLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.deptLabel.Location = New System.Drawing.Point(26, 480)
        Me.deptLabel.Name = "deptLabel"
        Me.deptLabel.Size = New System.Drawing.Size(36, 15)
        Me.deptLabel.TabIndex = 488
        Me.deptLabel.Text = "Dept."
        '
        'fundLabel
        '
        Me.fundLabel.AutoSize = True
        Me.fundLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.fundLabel.Location = New System.Drawing.Point(26, 532)
        Me.fundLabel.Name = "fundLabel"
        Me.fundLabel.Size = New System.Drawing.Size(35, 15)
        Me.fundLabel.TabIndex = 487
        Me.fundLabel.Text = "Fund"
        '
        'encumbLabel
        '
        Me.encumbLabel.AutoSize = True
        Me.encumbLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.encumbLabel.Location = New System.Drawing.Point(552, 533)
        Me.encumbLabel.Name = "encumbLabel"
        Me.encumbLabel.Size = New System.Drawing.Size(90, 15)
        Me.encumbLabel.TabIndex = 489
        Me.encumbLabel.Text = "Encumbrances"
        '
        'expendLabel
        '
        Me.expendLabel.AutoSize = True
        Me.expendLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.expendLabel.Location = New System.Drawing.Point(552, 508)
        Me.expendLabel.Name = "expendLabel"
        Me.expendLabel.Size = New System.Drawing.Size(79, 15)
        Me.expendLabel.TabIndex = 492
        Me.expendLabel.Text = "Expenditures"
        '
        'budgetLabel
        '
        Me.budgetLabel.AutoSize = True
        Me.budgetLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.budgetLabel.Location = New System.Drawing.Point(552, 483)
        Me.budgetLabel.Name = "budgetLabel"
        Me.budgetLabel.Size = New System.Drawing.Size(46, 15)
        Me.budgetLabel.TabIndex = 491
        Me.budgetLabel.Text = "Budget"
        '
        'glkeynameLabel
        '
        Me.glkeynameLabel.AutoSize = True
        Me.glkeynameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.glkeynameLabel.Location = New System.Drawing.Point(26, 558)
        Me.glkeynameLabel.Name = "glkeynameLabel"
        Me.glkeynameLabel.Size = New System.Drawing.Size(60, 15)
        Me.glkeynameLabel.TabIndex = 490
        Me.glkeynameLabel.Text = "GL Name"
        '
        'glkeyLabel
        '
        Me.glkeyLabel.AutoSize = True
        Me.glkeyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.glkeyLabel.Location = New System.Drawing.Point(26, 506)
        Me.glkeyLabel.Name = "glkeyLabel"
        Me.glkeyLabel.Size = New System.Drawing.Size(46, 15)
        Me.glkeyLabel.TabIndex = 486
        Me.glkeyLabel.Text = "GL Key"
        '
        'deptText
        '
        Me.deptText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deptText.Location = New System.Drawing.Point(119, 475)
        Me.deptText.Name = "deptText"
        Me.deptText.Size = New System.Drawing.Size(56, 22)
        Me.deptText.TabIndex = 478
        '
        'encumberText
        '
        Me.encumberText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.encumberText.Location = New System.Drawing.Point(647, 528)
        Me.encumberText.Name = "encumberText"
        Me.encumberText.Size = New System.Drawing.Size(167, 22)
        Me.encumberText.TabIndex = 484
        '
        'expendText
        '
        Me.expendText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expendText.Location = New System.Drawing.Point(647, 502)
        Me.expendText.Name = "expendText"
        Me.expendText.Size = New System.Drawing.Size(167, 22)
        Me.expendText.TabIndex = 483
        '
        'budgetText
        '
        Me.budgetText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.budgetText.Location = New System.Drawing.Point(647, 476)
        Me.budgetText.Name = "budgetText"
        Me.budgetText.Size = New System.Drawing.Size(167, 22)
        Me.budgetText.TabIndex = 482
        '
        'fundText
        '
        Me.fundText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fundText.Location = New System.Drawing.Point(119, 527)
        Me.fundText.Name = "fundText"
        Me.fundText.Size = New System.Drawing.Size(56, 22)
        Me.fundText.TabIndex = 479
        '
        'glnameText
        '
        Me.glnameText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.glnameText.Location = New System.Drawing.Point(119, 553)
        Me.glnameText.Name = "glnameText"
        Me.glnameText.Size = New System.Drawing.Size(366, 22)
        Me.glnameText.TabIndex = 481
        '
        'glkeyText
        '
        Me.glkeyText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.glkeyText.Location = New System.Drawing.Point(119, 501)
        Me.glkeyText.Name = "glkeyText"
        Me.glkeyText.Size = New System.Drawing.Size(100, 22)
        Me.glkeyText.TabIndex = 480
        '
        'fundsNavigator
        '
        Me.fundsNavigator.AddNewItem = Nothing
        Me.fundsNavigator.AutoSize = False
        Me.fundsNavigator.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fundsNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.fundsNavigator.DeleteItem = Nothing
        Me.fundsNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.fundsNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fundsaddButton, Me.fundsdeleteButton, Me.fundsundoButton, Me.fundsaveButton, Me.ToolStripSeparator3, Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.ToolStripSeparator1, Me.tsbFundingManageAll})
        Me.fundsNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.fundsNavigator.Location = New System.Drawing.Point(12, 413)
        Me.fundsNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.fundsNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.fundsNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.fundsNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.fundsNavigator.Name = "fundsNavigator"
        Me.fundsNavigator.Padding = New System.Windows.Forms.Padding(1)
        Me.fundsNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.fundsNavigator.Size = New System.Drawing.Size(855, 28)
        Me.fundsNavigator.TabIndex = 494
        Me.fundsNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(0, 0)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'fundsaddButton
        '
        Me.fundsaddButton.Image = CType(resources.GetObject("fundsaddButton.Image"), System.Drawing.Image)
        Me.fundsaddButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fundsaddButton.Name = "fundsaddButton"
        Me.fundsaddButton.Padding = New System.Windows.Forms.Padding(2)
        Me.fundsaddButton.Size = New System.Drawing.Size(53, 24)
        Me.fundsaddButton.Text = "A&dd"
        '
        'fundsdeleteButton
        '
        Me.fundsdeleteButton.Image = CType(resources.GetObject("fundsdeleteButton.Image"), System.Drawing.Image)
        Me.fundsdeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fundsdeleteButton.Name = "fundsdeleteButton"
        Me.fundsdeleteButton.Padding = New System.Windows.Forms.Padding(2)
        Me.fundsdeleteButton.Size = New System.Drawing.Size(64, 24)
        Me.fundsdeleteButton.Text = "Delete"
        '
        'fundsundoButton
        '
        Me.fundsundoButton.Image = CType(resources.GetObject("fundsundoButton.Image"), System.Drawing.Image)
        Me.fundsundoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fundsundoButton.Name = "fundsundoButton"
        Me.fundsundoButton.Padding = New System.Windows.Forms.Padding(2)
        Me.fundsundoButton.Size = New System.Drawing.Size(60, 24)
        Me.fundsundoButton.Text = "Undo"
        '
        'fundsaveButton
        '
        Me.fundsaveButton.Image = CType(resources.GetObject("fundsaveButton.Image"), System.Drawing.Image)
        Me.fundsaveButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fundsaveButton.Name = "fundsaveButton"
        Me.fundsaveButton.Padding = New System.Windows.Forms.Padding(2)
        Me.fundsaveButton.Size = New System.Drawing.Size(55, 24)
        Me.fundsaveButton.Text = "Save"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 23)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BindingNavigatorPositionItem.Margin = New System.Windows.Forms.Padding(3)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(30, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'tsbFundingManageAll
        '
        Me.tsbFundingManageAll.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllActiveFundingRecordsToolStripMenuItem, Me.InactiveFundingRecordsAllToolStripMenuItem})
        Me.tsbFundingManageAll.Image = CType(resources.GetObject("tsbFundingManageAll.Image"), System.Drawing.Image)
        Me.tsbFundingManageAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFundingManageAll.Margin = New System.Windows.Forms.Padding(2)
        Me.tsbFundingManageAll.Name = "tsbFundingManageAll"
        Me.tsbFundingManageAll.Size = New System.Drawing.Size(116, 20)
        Me.tsbFundingManageAll.Text = "View All Funds"
        '
        'AllActiveFundingRecordsToolStripMenuItem
        '
        Me.AllActiveFundingRecordsToolStripMenuItem.CheckOnClick = True
        Me.AllActiveFundingRecordsToolStripMenuItem.Name = "AllActiveFundingRecordsToolStripMenuItem"
        Me.AllActiveFundingRecordsToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.AllActiveFundingRecordsToolStripMenuItem.Text = "Active"
        '
        'InactiveFundingRecordsAllToolStripMenuItem
        '
        Me.InactiveFundingRecordsAllToolStripMenuItem.CheckOnClick = True
        Me.InactiveFundingRecordsAllToolStripMenuItem.Name = "InactiveFundingRecordsAllToolStripMenuItem"
        Me.InactiveFundingRecordsAllToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.InactiveFundingRecordsAllToolStripMenuItem.Text = "Inactive"
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.BackColor = System.Drawing.SystemColors.ControlLight
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.Location = New System.Drawing.Point(1, 29)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(611, 36)
        Me.miniToolStrip.TabIndex = 455
        '
        'AssignFundsButton
        '
        Me.AssignFundsButton.Enabled = False
        Me.AssignFundsButton.Image = CType(resources.GetObject("AssignFundsButton.Image"), System.Drawing.Image)
        Me.AssignFundsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AssignFundsButton.Name = "AssignFundsButton"
        Me.AssignFundsButton.Padding = New System.Windows.Forms.Padding(3)
        Me.AssignFundsButton.Size = New System.Drawing.Size(122, 26)
        Me.AssignFundsButton.Text = "&Assign to Project"
        '
        'ImportFundsButton
        '
        Me.ImportFundsButton.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ImportFundsButton.CheckOnClick = True
        Me.ImportFundsButton.Image = CType(resources.GetObject("ImportFundsButton.Image"), System.Drawing.Image)
        Me.ImportFundsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportFundsButton.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.ImportFundsButton.Name = "ImportFundsButton"
        Me.ImportFundsButton.Padding = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.ImportFundsButton.Size = New System.Drawing.Size(87, 23)
        Me.ImportFundsButton.Text = "Import File"
        '
        'fundsnewLabel
        '
        Me.fundsnewLabel.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.fundsnewLabel.Name = "fundsnewLabel"
        Me.fundsnewLabel.Size = New System.Drawing.Size(65, 26)
        Me.fundsnewLabel.Text = "new funds:"
        '
        'fundsnewTextbox
        '
        Me.fundsnewTextbox.Enabled = False
        Me.fundsnewTextbox.Name = "fundsnewTextbox"
        Me.fundsnewTextbox.Size = New System.Drawing.Size(30, 29)
        '
        'fundsupdateLabel
        '
        Me.fundsupdateLabel.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.fundsupdateLabel.Name = "fundsupdateLabel"
        Me.fundsupdateLabel.Size = New System.Drawing.Size(87, 26)
        Me.fundsupdateLabel.Text = "updated funds:"
        '
        'fundsupdateTextbox
        '
        Me.fundsupdateTextbox.Enabled = False
        Me.fundsupdateTextbox.Margin = New System.Windows.Forms.Padding(1, 0, 3, 0)
        Me.fundsupdateTextbox.Name = "fundsupdateTextbox"
        Me.fundsupdateTextbox.Size = New System.Drawing.Size(30, 29)
        '
        'fundsimpacceptionsDropDown
        '
        Me.fundsimpacceptionsDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.fundsimpacceptionsDropDown.Enabled = False
        Me.fundsimpacceptionsDropDown.Image = Global.FNSB_Facilities_Projects.My.Resources.Resources.Annotate_Blocked_large
        Me.fundsimpacceptionsDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.fundsimpacceptionsDropDown.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.fundsimpacceptionsDropDown.Name = "fundsimpacceptionsDropDown"
        Me.fundsimpacceptionsDropDown.Size = New System.Drawing.Size(29, 26)
        Me.fundsimpacceptionsDropDown.Text = "Import Exceptions"
        Me.fundsimpacceptionsDropDown.ToolTipText = "Import Exceptions List Management"
        '
        'fundsactionToolStrip
        '
        Me.fundsactionToolStrip.AutoSize = False
        Me.fundsactionToolStrip.BackColor = System.Drawing.SystemColors.ControlLight
        Me.fundsactionToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.fundsactionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignFundsButton, Me.ImportFundsButton, Me.fundsnewLabel, Me.fundsnewTextbox, Me.fundsupdateLabel, Me.fundsupdateTextbox, Me.fundsimpacceptionsDropDown, Me.projectsearchTextbox, Me.ToolStripButton1})
        Me.fundsactionToolStrip.Location = New System.Drawing.Point(2, 2)
        Me.fundsactionToolStrip.Name = "fundsactionToolStrip"
        Me.fundsactionToolStrip.Size = New System.Drawing.Size(872, 29)
        Me.fundsactionToolStrip.TabIndex = 455
        Me.fundsactionToolStrip.Text = "ToolStrip1"
        '
        'projectsearchTextbox
        '
        Me.projectsearchTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.projectsearchTextbox.Name = "projectsearchTextbox"
        Me.projectsearchTextbox.Size = New System.Drawing.Size(240, 29)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 26)
        Me.ToolStripButton1.Text = "Search"
        '
        'projectsDataGrid
        '
        Me.projectsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.projectsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.projectsDataGrid.DefaultCellStyle = DataGridViewCellStyle12
        Me.projectsDataGrid.Location = New System.Drawing.Point(12, 57)
        Me.projectsDataGrid.Name = "projectsDataGrid"
        Me.projectsDataGrid.RowTemplate.Height = 24
        Me.projectsDataGrid.Size = New System.Drawing.Size(852, 175)
        Me.projectsDataGrid.TabIndex = 497
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 498
        Me.Label1.Text = "Projects"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 498
        Me.Label2.Text = "Funds"
        '
        'PublicWorksFunding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(876, 630)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fundsactionToolStrip)
        Me.Controls.Add(Me.projectsDataGrid)
        Me.Controls.Add(Me.fundsNavigator)
        Me.Controls.Add(Me.balanceLabel)
        Me.Controls.Add(Me.balanceText)
        Me.Controls.Add(Me.deptLabel)
        Me.Controls.Add(Me.fundLabel)
        Me.Controls.Add(Me.encumbLabel)
        Me.Controls.Add(Me.expendLabel)
        Me.Controls.Add(Me.budgetLabel)
        Me.Controls.Add(Me.glkeynameLabel)
        Me.Controls.Add(Me.glkeyLabel)
        Me.Controls.Add(Me.deptText)
        Me.Controls.Add(Me.encumberText)
        Me.Controls.Add(Me.expendText)
        Me.Controls.Add(Me.budgetText)
        Me.Controls.Add(Me.fundText)
        Me.Controls.Add(Me.glnameText)
        Me.Controls.Add(Me.glkeyText)
        Me.Controls.Add(Me.fundsGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "PublicWorksFunding"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Public Works Projects - Funding Detail"
        CType(Me.fundsGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fundsNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fundsNavigator.ResumeLayout(False)
        Me.fundsNavigator.PerformLayout()
        Me.fundsactionToolStrip.ResumeLayout(False)
        Me.fundsactionToolStrip.PerformLayout()
        CType(Me.projectsDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents fundsGridView As System.Windows.Forms.DataGridView
    Friend WithEvents balanceLabel As System.Windows.Forms.Label
    Friend WithEvents balanceText As System.Windows.Forms.TextBox
    Friend WithEvents deptLabel As System.Windows.Forms.Label
    Friend WithEvents fundLabel As System.Windows.Forms.Label
    Friend WithEvents encumbLabel As System.Windows.Forms.Label
    Friend WithEvents expendLabel As System.Windows.Forms.Label
    Friend WithEvents budgetLabel As System.Windows.Forms.Label
    Friend WithEvents glkeynameLabel As System.Windows.Forms.Label
    Friend WithEvents glkeyLabel As System.Windows.Forms.Label
    Friend WithEvents deptText As System.Windows.Forms.TextBox
    Friend WithEvents encumberText As System.Windows.Forms.TextBox
    Friend WithEvents expendText As System.Windows.Forms.TextBox
    Friend WithEvents budgetText As System.Windows.Forms.TextBox
    Friend WithEvents fundText As System.Windows.Forms.TextBox
    Friend WithEvents glnameText As System.Windows.Forms.TextBox
    Friend WithEvents glkeyText As System.Windows.Forms.TextBox
    Friend WithEvents fundsNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents fundsaddButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents fundsdeleteButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents fundsundoButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents fundsaveButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents miniToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents AssignFundsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImportFundsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents fundsnewLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents fundsnewTextbox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents fundsupdateLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents fundsupdateTextbox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents fundsimpacceptionsDropDown As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents fundsactionToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents projectsDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents projectsearchTextbox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tsbFundingManageAll As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents AllActiveFundingRecordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InactiveFundingRecordsAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
