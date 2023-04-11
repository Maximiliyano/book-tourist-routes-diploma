import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
// TODO issue with apiUrl in enviroment is empty

@Injectable({
  providedIn: 'root'
})
export class HttpInternalService {
  public headers = new HttpHeaders();
  public baseUrl: string = "https://localhost:44333";

  constructor(private http: HttpClient) { }

  public getHeaders(): HttpHeaders {
    return this.headers;
  }

  public getFullRequest<T>(url: string, httpParams?: any): Observable<HttpResponse<T>> {
    return this.http.get<T>(this.buildUrl(url), { observe: 'response', headers: this.getHeaders(), params: httpParams });
  }

  public buildUrl(url: string): string {
    if (url.startsWith('http://') || url.startsWith('https://')) {
      return url;
    }
    return this.baseUrl + url;
  }
}
