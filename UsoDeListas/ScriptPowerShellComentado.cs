namespace UsoDeListas
{
    public class ScriptPowerShellComentado
    {
//        cls

//Write-Host "Verificando PowerShell snap-in" -ForegroundColor Magenta

//$snapin=Get-PSSnapin |? {$_.Name -eq 'Microsoft.SharePoint.PowerShell'}

//if ($snapin -eq $null) {
//    Write-Host "Cargando SharePoint PowerShell snap-in..." -ForegroundColor DarkMagenta
//    Add-PSSnapin "Microsoft.SharePoint.PowerShell"
//}

//Write-Host "SharePoint PowerShell snap-in cargado." -ForegroundColor Green
//$webUrl = "http://vmforsharepoint/" //CAMBIAR EN CLASE
//$listName = "PresupuestoMaterial"
//$numberItemsToCreate = 1000
//$itemNamePrefix = "Bicho"
//$web = Get-SPWeb $webUrl
//$list = $web.Lists[$listName]

//for($i=1; $i -le $numberItemsToCreate; $i++)
//{
//$newItemSuffix = $i.ToString("00000")
//$newItem = $list.AddItem()
//$newItem["Title"] = "$itemNamePrefix$newItemSuffix"
//$newItem["Peticion"]="$itemNamePrefix"
//$newItem["Realizada_x0020_por"]="Luis Gil"
//$newItem["Fecha"]="03/03/2016"
//$newItem["Cantidad"] = $i
//$newItem["Importe"] = $i*10
//$newItem.Update()
//write-host "Elemento creado: $itemNamePrefix$newItemSuffix"
//}
// $web.Dispose()
    }
}