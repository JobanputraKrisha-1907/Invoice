import { HttpClient } from "@angular/common/http";
import { Component, OnInit, ViewChild } from "@angular/core";


@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['../../../assets/css/invoice.component.css']

})
export class InvoiceComponent implements OnInit {
  @ViewChild('frmdetails', { static: true }) frmdetails: any;
  selected: string | undefined;
  customer: any;
  invoicecustomer: any;
  invoicenumber: any;
  invoicedate: any;
  itemlist: any;
  total: any;
  quantity: any;
  price: any;
  I: any;
  note: any;
  rows: any;
  TotalTax: any = 0;
  GrandTotal: any = 0;
  subTotal: any = 0;
  row: any;
  product: any;
  selectedProducts: any;
  description: any;
  qty: any;
  tax: any;
  invoicenote: any;
  deletedItems: any[] = [];
  selectedId: any;
  //cuflag = true;
  //addnowbtn = false;
  tableArray: Array<any> = [
    //  { id: 1 , productName: '', description: '', price: 0, qty: 1, tax: 0, total: 0 },
  ];
  updateavailableProducts: any;



  //constructor
  constructor(private http: HttpClient) { }

  //Oninit method
  ngOnInit() {
    this.http.get<any>('Customers/Customerdata').pipe().subscribe(data => {
      data = JSON.parse(data.data);
      this.customer = data;
    })

    this.http.get<any>('Product/Productdata').pipe().subscribe(data => {
      data = JSON.parse(data.data);
      this.itemlist = data;

    })


  }

  //generate invoice number
  generateInvoiceNumber() {
    const currentDate = new Date();
    const randomNumber = Math.floor(Math.random() * 10000);
    const dateString =
      currentDate.getFullYear() +
      (currentDate.getMonth() + 1) +
      currentDate.getDate() +
      currentDate.getHours() +
      currentDate.getMinutes() +
      currentDate.getSeconds();
    this.invoicenumber = dateString + randomNumber;
  }

  // selectproduct
  selectProduct(row: any, productName: any) {
    const selectedProduct = this.itemlist.find((product: { productname: string; }) => product.productname === productName);
    if (selectedProduct) {


      row.description = selectedProduct?.productdescription;
      row.productName = selectedProduct?.productname;
      row.selectedProduct = productName;
      row.price = selectedProduct?.productprice;
      row.tax = selectedProduct?.producttax;
      let ro = selectedProduct?.productprice * row.qty * (1 + (selectedProduct?.producttax || 0) / 100);
      row.total = ro;
      this.calculateTotals();
      this.deletedItems.push(selectedProduct?.productId);
      //this.updateavailableProducts();

      console.log(this.tableArray);
    }
    /*  this.selectedId = selectedProduct?.productId;*/

  }
  sele(name: any) {
    if (this.isProductSelectedInOtherRows(name)) {
      return true;

    }
    return false;
  }

  isProductSelectedInOtherRows(productName: string): boolean {
    return this.tableArray.some((row: { selectedProduct: string; }) => row.selectedProduct === productName);
  }

  updateavailableproducts() {
    this.tableArray.forEach(row => {
      row.availableproducts = this.itemlist.filter((product: { productname: any; }) => {
        return !this.tableArray.some((otherrow: { selectedproduct: any; }) => otherrow.selectedproduct === product);
      });
    });
  }

  //calculate totals
  calculateTotals() {
    this.TotalTax = 0;
    this.subTotal = 0;
    this.GrandTotal = 0;

    this.tableArray.forEach((row: any) => {
      this.subTotal += row.price * (row.qty);
      this.TotalTax += Number(row.tax);
      this.GrandTotal += Number(row.total);

    })

  }
  //ok() {
  //  this.cuflag = false;
  //  this.addnowbtn = false;
  //}

  //qtychange
  qtyChange(row: any, Qty: number) {

    let ro = row.price * Qty;
    row.total = ro;
    this.subTotal = row.total;
    this.GrandTotal = this.subTotal + this.TotalTax
  }


  //addrow
  addRow() {

    this.tableArray.push({
      id: this.tableArray.length + 1,
      product: '',
      description: '',
      price: 0,
      qty: 1,
      tax: 0,
      total: 0
    })
    console.log(this.tableArray)

  }

  //cancel
  cancel() {
    location.reload();
  }

  //save the form
  save() {
    //if (this.cuflag) {
    //  alert("fill data");
    //} else {
    debugger;
    let param = {
      "BillTo": this.invoicecustomer,
      "InvoiceDate": this.invoicedate,
      "productlist": this.tableArray,
      "invoicenote": this.note,
      "subTotal": this.subTotal,
      "totaltax": this.TotalTax,
      "Grandtotal": this.GrandTotal
    }

    this.http.post<any>('Invoice/InsertInvoice', { "JSONData": JSON.stringify(param) }).subscribe(data => {
      this.itemlist = data;
      alert("Your Data has been Submitted Successfully!!");
    });
  }

  //}

  //gettotal
  getTotal(inner: any): any {
    let multiplication = inner * this.price;
    return multiplication;
  }

  //removerow 
  removeRow(index: number) {
    this.tableArray.splice(index, 1);


  }

}
