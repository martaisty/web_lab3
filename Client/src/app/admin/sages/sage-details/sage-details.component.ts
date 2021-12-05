import {Component, OnInit} from '@angular/core';
import {Sage} from '../sage';
import {ActivatedRoute, Router} from '@angular/router';
import {SageService} from '../sage.service';

@Component({
  selector: 'app-sage-details',
  templateUrl: './sage-details.component.html',
  styleUrls: ['./sage-details.component.scss']
})
export class SageDetailsComponent implements OnInit {
  sage: Sage = {}
  displayedColumns: string[] = ['name', 'description'];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private sageService: SageService) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.sage = data.sage;
    });
  }

  editSage() {
    this.router.navigate(['edit'], {relativeTo: this.route});
  }

  deleteSage() {
    if (confirm('Are you sure you want to delete sage ' + this.sage.name)) {
      this.sageService.deleteSage(this.sage.id!!)
      this.router.navigate(['/admin/sages']);
    }
  }
}
