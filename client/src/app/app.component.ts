import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ColDef, GridApi, GridReadyEvent } from 'ag-grid-community';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  private gridApi: GridApi | null = null;
  columnDefs: ColDef[] = [];

  rowData: any[] = [];

  constructor(private http: HttpClient) {}

  onGridReady(params: GridReadyEvent) {
    this.gridApi = params.api;
    this.http.get<any[]>('http://localhost:5115/cities')
      .subscribe(cities => {
        this.rowData = cities;
        const obj = this.rowData[0];
        if (!obj) return;

        this.columnDefs = Object.keys(obj).map<ColDef>(k => {
          const def: ColDef = { field: k }
          return def;
        });

        console.log(this.rowData);
        console.log(this.columnDefs);

        this.gridApi?.setColumnDefs(this.columnDefs);
      });
  }
}
