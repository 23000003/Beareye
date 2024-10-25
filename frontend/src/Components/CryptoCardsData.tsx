import React from 'react'

export default function CryptoCardsData() {
    return (
        <>
        <div className='flex flex-row'>
            <div className='w-3/4 h-80 bg-stone-900 rounded-md flex flex-row'>
                <div className='h-full' style={{width: "30%"}}>

                </div>
                <span className='my-5 bg-stone-800' style={{width: "1px"}}></span> {/**Vertical line */}
                <div className='h-full' style={{width: "30%"}}>

                </div>
                <span className='my-5 bg-stone-800' style={{width: "1px"}}></span>
                <div className='w-2/5 h-full '>

                </div>
            </div>
            <div className='w-1/4 h-80'>

            </div>
        </div>
        <div className='my-7'>
            <div className='w-full h-72 flex flex-row gap-5'>
                <div className='w-2/6 h-full bg-stone-900 rounded-md'>
                
                </div>
                <div className='w-2/6 h-full bg-stone-900 rounded-md'>
                
                </div>
                <div className='w-2/6 h-full bg-stone-900 rounded-md'>
                
                </div>
            </div>
        </div>
        </>
    )
}
