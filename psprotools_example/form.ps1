$MyButton_Click = {
	[System.Windows.Forms.MessageBox]::Show("Hi!")
	$MyLabel.Text = "Real good..."
}
Add-Type -AssemblyName System.Windows.Forms
. (Join-Path $PSScriptRoot 'form.designer.ps1')
$MainForm.ShowDialog()