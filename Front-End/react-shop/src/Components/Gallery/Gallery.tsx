import React, { useEffect, useState } from 'react';
import SubCategories from './SubCategories'
import './Gallery.scss'

function Gallery() {
    
  return (
    <div className="Gallery">
        <div className='sideMenu'>
            <SubCategories />
        </div>
        <div>

        </div>
    </div>
  );
}

export default Gallery;
