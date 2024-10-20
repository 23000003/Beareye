import React, { useState } from 'react'


export default function Dashboard(){
    
    const [searchInput, setSearchInput] = useState<string>('');

    return (
        <div className='px-2'>
            <div className='h-16'>
                <div className='flex flex-row h-full w-full justify-center items-center'>
                    <div className='border w-1/2 h-12 border-orange-400 bg-stone-800 opacity-80 rounded-sm flex flex-row items-center gap-4 justify-between'>
                        <i className="fa-solid fa-magnifying-glass text-stone-500 text-xs ml-3"></i>
                        <input type="text" 
                            className='w-full bg-transparent text-xs outline-none' 
                            placeholder='Search for Crypto Tokens, Stocks, Traders...'
                            onChange={(e) => setSearchInput(e.target.value)}
                            value={searchInput}
                        />
                        <div 
                            className=' bg-stone-600 h-3 mt-1 w-4 flex flex-row items-center justify-center rounded-2xl' 
                            style={{visibility: !searchInput ? 'hidden' : 'visible'}}
                        >
                            <span 
                                className=' text-black -mt-0.5 cursor-pointer' 
                                style={{fontSize: '10px'}}
                                onClick={() => setSearchInput('')}
                            >x</span>
                        </div>
                        <div className='bg-orange-500 px-4 h-8 flex flex-row items-center mr-3 text-black hover:text-white duration-200 cursor-pointer'>
                            <span className='text-sm font-semibold'>Search</span>
                        </div>
                        
                    </div>
                </div>
            </div>
            <div>
                testHEY
            </div>  
        </div>
    )

}
