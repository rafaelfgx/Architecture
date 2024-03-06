import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { AppButtonComponent } from "src/app/components/button/button.component";
import { AppLabelComponent } from "src/app/components/label/label.component";
import { AppSelectCommentComponent } from "src/app/components/select/comment.select.component";
import { AppSelectPostComponent } from "src/app/components/select/post.select.component";
import { AppSelectUserComponent } from "src/app/components/select/user.select.component";

@Component({
    selector: "app-form",
    templateUrl: "./form.component.html",
    standalone: true,
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
export class AppFormComponent {
    disabled = false;

    form = inject(FormBuilder).group({
        userId: [0, Validators.required],
        postId: [0, Validators.required],
        commentId: [0, Validators.required]
    });

    set = () => this.form.patchValue({ userId: 10, postId: 100, commentId: 500 });
}
