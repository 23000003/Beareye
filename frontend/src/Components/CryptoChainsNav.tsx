import React from 'react'

export default function CryptoChainsNav() {
    return (
        <>
        <div className='flex flex-row gap-6'>
            <div className='cursor-pointer hover:bg-gray-700 px-2 py-1'>
                <span className=''>All Chains</span>
            </div>
            <span className='text-stone-800 font-thin'>|</span>
            <div className='cursor-pointer hover:bg-gray-700 px-2 py-1'>
                <span className=''>Solana</span>
            </div>
            <span className='text-stone-800 font-thin'>|</span>
            <div className='cursor-pointer hover:bg-gray-700 px-2 py-1'>
                <span className=''>Ethereum</span>
            </div>
            <span className='text-stone-800 font-thin'>|</span>
            <div className='cursor-pointer hover:bg-gray-700 px-2 py-1'>
                <span className=''>Sui</span>
            </div>
            <span className='text-stone-800 font-thin'>|</span>
            <div className='cursor-pointer hover:bg-gray-700 px-2 py-1'>
                <span className=''>BNB Chain</span>
            </div>
            <span className='text-stone-800 font-thin'>|</span>
            <div className='cursor-pointer hover:bg-gray-700 px-2 py-1'>
                <span className=''>Polygon</span>
            </div>
            <span className='text-stone-800 font-thin'>|</span>
            <div className='cursor-pointer hover:bg-gray-700 px-2 py-1'>
                <span className=''>Bitcoin</span>
            </div>
            <span className='text-stone-800 font-thin'>|</span>
        </div>
        <hr className='h-px border-0 dark:bg-stone-800'/>  
        </>
    )
}
