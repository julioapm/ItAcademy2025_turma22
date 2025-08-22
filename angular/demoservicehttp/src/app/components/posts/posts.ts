import { Component, inject, OnInit } from '@angular/core';
import { PostsService } from '../../services/postsservice';
import { Observable, of, catchError } from 'rxjs';
import { Post } from '../../models/post';
import { AsyncPipe } from '@angular/common';
import { tratadorErro } from '../../utils/tratadorhttp.js';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.html',
  styleUrl: './posts.css',
  imports: [AsyncPipe],
})
export class Posts implements OnInit {
  private postsService = inject(PostsService);
  posts$: Observable<Post[]> = of([]);

  ngOnInit() {
    this.posts$ = this.postsService
      .buscarTodosPosts()
      .pipe(catchError(tratadorErro));
  }

}
