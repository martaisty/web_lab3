import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from 'rxjs';
import {Sage} from '../sage';
import {SageService} from '../sage.service';

@Component({
  selector: 'app-sage-list',
  templateUrl: './sage-list.component.html',
  styleUrls: ['./sage-list.component.scss']
})
export class SageListComponent implements OnInit, OnDestroy {
  private _subscription: Subscription | undefined;

  sages: Sage[] = [];

  constructor(private service: SageService) {
  }

  ngOnInit(): void {
    this._subscription = this.service.sages.subscribe(sages => this.sages = sages);
    this.service.getAllSages();
  }

  ngOnDestroy(): void {
    this._subscription?.unsubscribe();
  }
}
