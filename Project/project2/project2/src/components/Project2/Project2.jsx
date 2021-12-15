import React from 'react';
import PostFilter from "./PostFilter";
import PostForm from "./PostForm";
import { PostList } from "./PostList";
import MyModel from "./UI/MyModel/MyModel";
import s from "./styles/Project2.module.css"
import MyButton from './UI/Button/MyButton';
import Loader from './UI/Loader/Loader';

const Project2 = ({createPost, filter, setFilter, sortedAndSearchedPosts, 
                removePost, setPosts, modal, setModal, isPostsLoading, postError, pagesArray}) => {


    return (
        <div className={s.pr}>
        <div className={s.project2}>
            <MyButton style={{margin: '0 0 0.5rem'}} onClick={()=>setModal(true)}>
                Create Post
            </MyButton>
            <MyModel visible={modal} setVisible={setModal}>
                <PostForm createPost={createPost} />
            </MyModel>
            <hr style={{ margin: '15px 0' }} />
            <PostFilter filter={filter} setFilter={setFilter} />
            {postError && <h1>Error ${postError}</h1>}
            {isPostsLoading
                ? <div style={{display:'flex', justifyContent:'center', marginTop:50}}><Loader /></div>
                :   <PostList posts={sortedAndSearchedPosts}
                            removePost={removePost}
                            setPost={setPosts}
                            title="List of posts"
                    />
            }
            <div className={s.pagination}>
            {pagesArray.map( p => <span>{p}</span>)}
            </div>
        </div>
        </div>
    );
};

export default Project2;