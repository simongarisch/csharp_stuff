# https://www.youtube.com/watch?v=lgPYdtcNRwg
$MainForm = New-Object -TypeName System.Windows.Forms.Form
[System.Windows.Forms.Button]$MyButton = $null
[System.Windows.Forms.Label]$MyLabel = $null
function InitializeComponent
{
$MyButton = (New-Object -TypeName System.Windows.Forms.Button)
$MyLabel = (New-Object -TypeName System.Windows.Forms.Label)
$MainForm.SuspendLayout()
#
#MyButton
#
$MyButton.Location = (New-Object -TypeName System.Drawing.Point -ArgumentList @([System.Int32]12,[System.Int32]12))
$MyButton.Name = [System.String]'MyButton'
$MyButton.Size = (New-Object -TypeName System.Drawing.Size -ArgumentList @([System.Int32]260,[System.Int32]23))
$MyButton.TabIndex = [System.Int32]0
$MyButton.Text = [System.String]'Push it'
$MyButton.UseCompatibleTextRendering = $true
$MyButton.UseVisualStyleBackColor = $true
$MyButton.add_Click($MyButton_Click)
#
#MyLabel
#
$MyLabel.Location = (New-Object -TypeName System.Drawing.Point -ArgumentList @([System.Int32]12,[System.Int32]47))
$MyLabel.Name = [System.String]'MyLabel'
$MyLabel.Size = (New-Object -TypeName System.Drawing.Size -ArgumentList @([System.Int32]260,[System.Int32]23))
$MyLabel.TabIndex = [System.Int32]1
$MyLabel.Text = [System.String]'...'
$MyLabel.TextAlign = [System.Drawing.ContentAlignment]::MiddleCenter
$MyLabel.UseCompatibleTextRendering = $true
#
#MainForm
#
$MainForm.ClientSize = (New-Object -TypeName System.Drawing.Size -ArgumentList @([System.Int32]284,[System.Int32]81))
$MainForm.Controls.Add($MyLabel)
$MainForm.Controls.Add($MyButton)
$MainForm.Name = [System.String]'MainForm'
$MainForm.Text = [System.String]'PS Example'
$MainForm.ResumeLayout($false)
Add-Member -InputObject $MainForm -Name base -Value $base -MemberType NoteProperty
Add-Member -InputObject $MainForm -Name MyButton -Value $MyButton -MemberType NoteProperty
Add-Member -InputObject $MainForm -Name MyLabel -Value $MyLabel -MemberType NoteProperty
}
. InitializeComponent
