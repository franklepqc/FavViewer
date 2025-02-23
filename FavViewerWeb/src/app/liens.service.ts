import { Injectable } from '@angular/core';
import { ILien } from './ILien';
import { concat, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LiensService {

  // Url.
  private url: string = '/lien';

  constructor(private httpClient: HttpClient) { }

  ajouter(titre: string, url: string): Observable<any> {
    return this.httpClient.post(this.url, {
      titre,
      url
    });
  }

  obtenir(): Observable<ILien[]> {
    return this.httpClient.get<ILien[]>(this.url);
  }

  supprimer(id: number): Observable<any> {
    return this.httpClient.delete(`${this.url}/${id}`);
  }
}
