import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import AppButtonComponent from "@components/button/button.component";
import AppLabelComponent from "@components/label/label.component";
import AppSelectCommentComponent from "@components/select/comment.select.component";
import AppSelectPostComponent from "@components/select/post.select.component";
import AppSelectUserComponent from "@components/select/user.select.component";

@Component({
    selector: "app-form",
    templateUrl: "./form.component.html",
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AppButtonComponent,
        AppLabelComponent,
        AppSelectCommentComponent,
        AppSelectPostComponent,
        AppSelectUserComponent
    ]
})
export default class AppFormComponent {
    disabled = false;

    form = inject(FormBuilder).group({
        userId: [0, Validators.required],
        postId: [0, Validators.required],
        commentId: [0, Validators.required]
    });

    set = () => this.form.patchValue({ userId: 10, postId: 100, commentId: 500 });
}
