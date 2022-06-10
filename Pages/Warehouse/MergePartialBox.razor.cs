﻿using Blazored.Toast.Services;
using MESystem.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace MESystem.Pages.Warehouse;

public partial class MergePartialBox : ComponentBase
{
    [Inject]
    IJSRuntime jSRuntime { get; set; }

    [Inject]
    TraceService? TraceDataService { get; set; }

    [Inject]
    IToastService Toast { get; set; }

    string? Scanfield { get; set; }
    string? Scanfield2 { get; set; }

    public string? Title { get; set; }

    //Scan for making palette only
    public int QtyPerBox;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await jSRuntime.InvokeVoidAsync("focusEditorByID", "BarcodeBox1");
        }
    }

    async void ResetInfo(bool backToStart)
    {
        if (backToStart)
        {
            Scanfield = "";
            Scanfield2 = "";
            //Update UI
            await UpdateUI();
        }
        else
        {
            Scanfield = string.Empty;
            await UpdateUI();
            await jSRuntime.InvokeVoidAsync("focusEditorByID", "ShippingScanField");
        }
    }

    async Task UpdateUI()
    {
        //Update UI
        if (ShouldRender())
        {
            await Task.Delay(5);
            await InvokeAsync(StateHasChanged);
        }
#if DEBUG
        Console.WriteLine("UI is updated");
#endif
    }


    // Check 2 Boxs
    private void GetInputfield(string content) { Scanfield = content; }
    private void GetInputfield2(string content) { Scanfield2 = content; }

    private async void HandleBarcodeBox1(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            // Check Error/Exist Barcode 

            if (!await CheckExistBarcode(Scanfield))
            {
                Toast.ShowError("Barcode not existed or In another pallet", "Error");
                await UpdateUI();
                return;
            }

            await UpdateUI();
            await jSRuntime.InvokeVoidAsync("focusEditorByID", "BarcodeBox2");

        }
    }
    private async void HandleBarcodeBox2(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            QtyPerBox = await TraceDataService.GetQtyFromTrace(3, Scanfield.Substring(0, 7));
            // Check Error/Exist Barcode 
            if (!await CheckExistBarcode(Scanfield2))
            {
                Toast.ShowError("Barcode not existed or In another pallet ", "Error");
                await UpdateUI();
                return;
            }

            // Check PartNo
            if (!await CheckPartNo(Scanfield.Substring(0, 7), Scanfield2.Substring(0, 7)))
            {
                Toast.ShowError("Error PartNo", "Error");
                await UpdateUI();
                return;
            }

            // Check Revision
            if (await TraceDataService.GetFamilyFromPartNo(Scanfield2.Substring(0, 7)) == "Phoenix")
                if (!await CheckRevisionBoxs(Scanfield.Substring(7, 2), Scanfield2.Substring(7, 2)))
                {
                    Toast.ShowError("Error Revision", "Error");
                    await UpdateUI();
                    return;
                }

            // Check Quantity <= StandardQuality Box
            if (!await CheckQuantity(Scanfield, Scanfield2))
            {
                Toast.ShowError("Quality of two partial boxs was exceed with standard quanity ob box", "Error");
                await UpdateUI();
                return;
            }


            //Update Barcode 2 to Barcode 1
            if (!await TraceDataService.UpdateBarcodeBox(Scanfield, Scanfield2))
            {
                Toast.ShowError("Update Error", "Error");
                await UpdateUI();
                return;
            }
            Toast.ShowSuccess("Merge Box Success, Please remove first barcode box !!!", "Success");
            ResetInfo(true);
            await UpdateUI();
            await jSRuntime.InvokeVoidAsync("focusEditorByID", "BarcodeBox1");
        }
    }

    // Check Error/Exist Barcode 
    public async Task<bool> CheckExistBarcode(string barcodeBox)
    {
        var result = await TraceDataService.CheckBarcodeBoxExist(barcodeBox);
        if (result.Count() > 0) return true;
        return false;
    }
    // Check PartNo 
    public async Task<bool> CheckPartNo(string partNo1, string partNo2)
    {
        if (partNo1 == partNo2) return true;
        return false;
    }

    // Check Revision IFS
    //public async Task<bool> CheckRevision(string revision)
    //{
    //    if (CurrentIFSRevision == revision) return true;
    //    return false;
    //}

    // Check Revision 2 box if phoenix
    public async Task<bool> CheckRevisionBoxs(string revbox1, string revbox2)
    {
        if (revbox1 == revbox2) return true;
        return false;
    }



    // Check Quantity <= Standard Quanlity box
    public async Task<bool> CheckQuantity(string barcodeBox1, string barcodeBox2)
    {
        var box1 = (await TraceDataService.GetBoxContentInformation(barcodeBox1, barcodeBox1.Substring(0, 7))).FirstOrDefault();
        var box2 = (await TraceDataService.GetBoxContentInformation(barcodeBox2, barcodeBox2.Substring(0, 7))).FirstOrDefault();
        if (box1.QtyBox + box2.QtyBox <= QtyPerBox) return true;
        return false;
    }

}
