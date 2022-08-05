﻿using MESystem.Data.TRACE;
using OfficeOpenXml;

namespace MESystem.Service
{
    public interface ITraceService
    {
        Task<IEnumerable<FinishedGood>?> CheckBarcodeBoxExist(string barcodeBox);
        Task<IEnumerable<FinishedGood>?> CheckBoxInAnyPallete(string barcodeBox);
        Task<IEnumerable<FinishedGood>?> CheckBoxLinkedToPO(string barcodeBox);
        Task<IEnumerable<FinishedGood>?> CheckExistBarcodeBox(string barcodeBox, string pONo);
        Task<IEnumerable<Shipment>> CheckExistShipmentId(string shipmentId);
        Task<IEnumerable<FinishedGood>?> CheckPartNoBarcodeBox(string barcodeBox, string partNo);
        int CountTotalQty(int? prepotting, string orderNo);
        Task<string> GetBarcodeLink(string barcode);
        Task<IEnumerable<FinishedGood>> GetBoxContentInformation(string barcodeBox, string partNo);
        Task<IEnumerable<CustomerOrder>> GetCustomerOrders();
        Task<IEnumerable<CustomerRevision>> GetCustomerRevision(int flag, string poNo, string family, string partNo, string orderNo);
        Task<IEnumerable<CustomerRevision>> GetCustomerRevisionByPartNo(string partNo);
        Task<IEnumerable<CustomerRevision>> GetCustomerRevisionByPartNo(string partNo, string family);
        Task<IEnumerable<vDepartmentStation>> GetDepartmentsStations();
        Task<IEnumerable<ModelProperties>> GetFamily(string FamilyInput, string partNoInput);
        Task<string> GetFamilyFromPartNo(string part_number);
        Task<IEnumerable<SiFamily>> GetFamilys();
        Task<IEnumerable<FinalResultFg>> GetFinalResult(string barcode);
        Task<IEnumerable<string>> GetFinishGoodByBarcodePallete(string barcodePallet);
        Task<vShopOrderLinks[]> GetLinkedShopOrders();
        Task<IEnumerable<Shipment>> GetLogisticData(string shipmentId = "ALL");
        Task<IEnumerable<vSiManufacturingToolPart>> GetManufToolParts();
        Task<IEnumerable<vSiManufacturingToolPart>> GetManufToolPartsByPartNo(string partNo);
        Task<IEnumerable<SiManufacturingTool>> GetManufTools();
        Task<IEnumerable<SiManufacturingToolType>> GetManufToolTypes();
        Task<int> GetMaxPaletteNumber(string part_no);
        Task<IEnumerable<Rework>> GetNGCode();
        Task<IEnumerable<vFinishedGoods>> GetOutputByOrderNoDay(string orderNo, string departmentNo);
        Task<string> GetPalletByBarcodeBox(string barcodeBox);
        Task<IEnumerable<ModelProperties>> GetPalletContentInfoByPartNo(string partNo);
        Task<IEnumerable<FinishedGood>> GetPalletContentInformation(string barcodePallet);
        Task<IEnumerable<ModelProperties>> GetPartNoList();
        Task<IEnumerable<vProductionLayout>> GetProductionLayouts(string partNo, string family);
        Task<IEnumerable<vProductionPlan>> GetProductionPlan(string department, string workcenterFilter);
        Task<IEnumerable<ProductionPlanLine>> GetProductionPlanLinesAsync(string departmentFilter);
        Task<IEnumerable<vProductionPlanJigs>> GetProductionPlanToolsJigs(string department, string workcenterFilter);
        Task<IEnumerable<SiProduct>> GetProducts();
        Task<IEnumerable<vSiProductFamily>> GetProductsFamilys();
        Task<int> GetQtyFromTrace(int flag, string part_number);
        Task<IEnumerable<FinishedGood>> GetQtyOfAddedPoNumbers(string poNumber, string partNo, string shipmentId);
        Task<IEnumerable<CustomerRevision>> GetRevisionByShopOrder(string orderNo);
        Task<ExcelWorksheets> GetSheetFromExcel(string filePath);
        Task<string> GetShipmentIdByBarcode(string barcode);
        Task<vShopOrderStates[]> GetShopOrderState(string filter);
        Task<vShopOrderStateMI[]> GetShopOrderStateMI(string filter);
        Task<IEnumerable<vProductionPlanIFS>> GetShopOrderStatus(string department);
        Task<IEnumerable<StockByFamily>> GetStockByFamily(string family);
        Task<ProductionPlanJigs> GetToolsJigsDetailsOrderNo(string orderNo);
        Task<bool> InsertEff(EffPlan eff);
        Task<bool> InsertPackingList(Shipment shipment);
        Task<bool> InsertPurchaseOrderNo(string barcodeBox, string poNumber, string shipmentId);
        Task<int> InsertReworkData(Rework dataInput);
        Task<List<EffPlan>> LoadDataSearchByDate(DateTime fromTime);
        Task<IEnumerable<ProductionLine>> LoadProductionLines(string departmentFilter);
        Task<ProductionPlanLine[]> Remove(ProductionPlanLine dataItem);
        Task RemoveManufTool(SiManufacturingTool newValues);
        Task RemoveManufToolLink(vSiManufacturingToolPart newValues);
        Task<bool> ShipmentInfoCalculation(string shipmentId);
        Task<bool> ShipmentInfoUpdate(string shipment_id);
        Task<bool> UpdateBarcodeBox(string barcode_box, string barcode_box2);
        Task UpdateBasePph(SiPartsPerHour newValues);
        Task<bool> UpdateContainerByIdx(int idx, string container);
        Task<bool> UpdateContainerNoToShipment(string shipmentId, string containerNo);
        Task UpdateFinishedGood(string barcode_box, string barcode_palette, int palette_number);
        Task UpdatefToolType(SiManufacturingToolType newValues);
        Task<bool> UpdateInvoiceByIdx(int idx, string invoiceNumber);
        Task<bool> UpdateInvoiceNumberToShipment(string shipmentId, string invoiceNumber);
        Task UpdateManufTool(SiManufacturingTool newValues);
        Task UpdateManufToolLink(SiManufacturingToolLink newValues);
        Task<bool> UpdateNetGrossDimensionSCM(int idx, double net, double gross, string dimension);
        Task<bool> UpdatePackingList(Shipment shipment);
        Task<bool> UpdatePackingListFull(string shipmentId);
        Task<bool> UpdatePackingListPartial(string shipmentId);
        Task<ProductionPlanLine> UpdateProductionValues(ProductionPlanLine dataItem, bool newInsert);
        Task<bool> UpdateRawDataByIdx(int idx, int rawdata);
        Task<bool> UpdateRemarkDB(CustomerRevision revision);
        Task<bool> UpdateRevision(CustomerRevision revision);
        Task<bool> UpdateShippingDateByIdx(int idx, DateTime? shippingDate);
        Task<bool> UpdateShippingDateToShipment(string shipmentId, DateTime? dateTime);
        Task<bool> UpdateShippingDayByIdx(int idx, string container);
        Task UpdateTargetPph(string productionLineId, int newTargetPPH);
        Task<bool> VerifyBoxPallet(string barcode_palette, int state, string shipmentID, string barcodeBox);
        Task<bool> VerifyPallet(string barcode_palette, int state, string shipmentID);
    }
}