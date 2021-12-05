import {Component, Input, OnInit} from '@angular/core';
import {Sage} from '../sage';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-sage',
  templateUrl: './sage.component.html',
  styleUrls: ['./sage.component.scss']
})
export class SageComponent implements OnInit {
  @Input() sage: Sage = {};

  constructor(private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit(): void {
  }

  sageDetails() {
    this.router.navigate([this.sage.id], {relativeTo: this.route});
  }
}
