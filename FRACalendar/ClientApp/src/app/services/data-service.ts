import { HttpClient, HttpHeaders } from "@angular/common/http";


export class DataService{

    httpOptions = {
        headers: new HttpHeaders({ 
          'Access-Control-Allow-Origin':'*'
        })
      };
      
    constructor(private http: HttpClient)
    {
        
    }

    public GetData (url : string)
    {
        return this.http.get(url, this.httpOptions);
    }

    public Delete(url: string)
    {
        return this.http.delete(url);
    }
}