import { Component, OnInit, inject } from '@angular/core';
import { PostsService } from '../../services/postServices';
import { Observable, of } from 'rxjs';
import { Post } from '../../models/post';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-posts',
  imports: [AsyncPipe],
  templateUrl: './posts.html',
  styleUrl: './posts.css'
})
export class Posts implements OnInit {
  private postsService = inject(PostsService);
  posts$: Observable<Post[]> = of([]);

  ngOnInit(): void {
    this.posts$ = this.postsService.buscarTodosPosts();
  }

}
