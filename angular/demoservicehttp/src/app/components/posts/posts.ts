import { Component, inject, OnInit } from '@angular/core';
import { PostsService } from '../../services/postsservice';
import { Observable, of } from 'rxjs';
import { Post } from '../../models/post';
import { AsyncPipe } from '@angular/common';

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
    this.posts$ = this.postsService.buscarTodosPosts();
  }

}
