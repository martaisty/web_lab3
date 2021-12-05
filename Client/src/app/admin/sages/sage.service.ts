import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment as env} from '../../../environments/environment';
import {Sage, SageUpdate} from './sage';

@Injectable()
export class SageService {
  private readonly _sages = new BehaviorSubject<Sage[]>([]);

  constructor(private http: HttpClient) {
  }

  get sages(): Observable<Sage[]> {
    return this._sages.asObservable();
  }

  get sagesSnapshot(): Sage[] {
    return this._sages.getValue();
  }

  getAllSages() {
    this.http.get<Sage[]>(`${env.apiUrl}/admin/Sages`)
      .subscribe(sages => this._sages.next(sages));
  }

  getSage(id: string): Observable<Sage> {
    return this.http.get<Sage>(`${env.apiUrl}/admin/Sages/${id}`);
  }

  addSage(newSage: SageUpdate) {
    this.http.post<Sage>(`${env.apiUrl}/admin/Sages`, newSage)
      .subscribe(sage => this._sages.next(this.sagesSnapshot.concat(sage)));
  }

  updateSage(newSage: SageUpdate) {
    this.http.put<Sage>(`${env.apiUrl}/admin/Sages`, newSage)
      .subscribe(sage => this._sages.next(this.sagesSnapshot.map(it => it.id === newSage.id ? sage : it)));
  }

  deleteSage(id: string) {
    this.http.delete(`${env.apiUrl}/admin/Sages/${id}`)
      .subscribe(() => this._sages.next(this.sagesSnapshot.filter(p => p.id !== id)));
  }
}
