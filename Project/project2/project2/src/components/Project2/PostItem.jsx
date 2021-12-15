import React from "react";
import "../../styles/App.css"
import MyButton from "./UI/Button/MyButton";
import s from "./styles/Project2.module.css"

export const PostItem = (props) => {
    return (
            <div className={s.post}>
                <div className={s.post__content}>
                    <strong>{props.number}. {props.post.title}</strong>
                    <div>{props.post.body}</div>
                </div>
                <div className={s.post__btns}>
                    <MyButton onClick={() => props.removePost(props.post)}>Delete</MyButton>
                </div>
            </div>
    )
}