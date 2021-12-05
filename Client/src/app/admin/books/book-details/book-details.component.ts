import {Component, OnInit} from '@angular/core';
import {Book} from '../book';
import {ActivatedRoute, Router} from '@angular/router';
import {BookService} from '../book.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.scss']
})
export class BookDetailsComponent implements OnInit {
  book: Book = {}
  displayedColumns: string[] = ['name', 'age', 'city'];

  constructor(private route: ActivatedRoute,
              private router: Router,
              private bookService: BookService) {
  }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.book = data.book;
    });
  }

  editBook() {
    this.router.navigate(['edit'], {relativeTo: this.route});
  }

  deleteBook() {
    if (confirm('Are you sure you want to delete book ' + this.book.name)) {
      this.bookService.deleteBook(this.book.id!!)
      this.router.navigate(['/admin/books']);
    }
  }
}
