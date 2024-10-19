import React from 'react'
import AppLogo from './SubComponents/AppLogo'

export default function Navbar() {
    return (
        <div className='h-16'>
            <div className='text-white flex flex-row items-center h-full justify-between px-4'>
               <AppLogo/>
               <div className='flex flex-row gap-12 font-semibold text-neutral-400' style={{fontSize: '13px'}}>
                    <div className='flex items-center cursor-pointer'>
                        <span>Rewards</span>
                        
                    </div>
                    <div className='flex items-center cursor-pointer'>
                        <span className='mr-1'>Terminal</span>
                        <svg viewBox="0 0 1024 1024" focusable="false" data-icon="caret-down" width="1em" height="1em" fill="currentColor" className='mt-0.3' aria-hidden="true">
                            <path d="M840.4 300H183.6c-19.7 0-30.7 20.8-18.5 35l328.4 380.8c9.4 10.9 27.5 10.9 37 0L858.9 335c12.2-14.2 1.2-35-18.5-35z">
                        </path>
                        </svg>
                    </div>
                    <div className='flex items-center cursor-pointer'>
                        <span className='mr-1'>Explore</span>
                        <svg viewBox="0 0 1024 1024" focusable="false" data-icon="caret-down" width="1em" height="1em" fill="currentColor" className='mt-0.3' aria-hidden="true">
                            <path d="M840.4 300H183.6c-19.7 0-30.7 20.8-18.5 35l328.4 380.8c9.4 10.9 27.5 10.9 37 0L858.9 335c12.2-14.2 1.2-35-18.5-35z">
                        </path>
                        </svg>
                    </div>
                    <div className='flex items-center cursor-pointer'>
                        <span className='mr-1'>Trade</span>
                        <svg viewBox="0 0 1024 1024" focusable="false" data-icon="caret-down" width="1em" height="1em" fill="currentColor" className='mt-0.3' aria-hidden="true">
                            <path d="M840.4 300H183.6c-19.7 0-30.7 20.8-18.5 35l328.4 380.8c9.4 10.9 27.5 10.9 37 0L858.9 335c12.2-14.2 1.2-35-18.5-35z">
                        </path>
                        </svg>
                    </div>
                    <div className='flex items-center cursor-pointer'>
                        <span className='mr-1'>PRO</span>
                        <svg viewBox="0 0 1024 1024" focusable="false" data-icon="caret-down" width="1em" height="1em" fill="currentColor" className='mt-0.3' aria-hidden="true">
                            <path d="M840.4 300H183.6c-19.7 0-30.7 20.8-18.5 35l328.4 380.8c9.4 10.9 27.5 10.9 37 0L858.9 335c12.2-14.2 1.2-35-18.5-35z">
                        </path>
                        </svg>
                    </div>
                    <div className='flex items-center cursor-pointer'>
                        <span className='mr-1'>Resources</span>
                        <svg viewBox="0 0 1024 1024" focusable="false" data-icon="caret-down" width="1em" height="1em" fill="currentColor" className='mt-0.3' aria-hidden="true">
                            <path d="M840.4 300H183.6c-19.7 0-30.7 20.8-18.5 35l328.4 380.8c9.4 10.9 27.5 10.9 37 0L858.9 335c12.2-14.2 1.2-35-18.5-35z">
                        </path>
                        </svg>
                    </div>
                    <div className='flex flex-row items-center gap-6'>
                        <div className='flex items-center border px-4 py-1 border-orange-400 text-orange-400 cursor-pointer hover:bg-gray-900 duration-300'>
                            <span>Web3 log in</span>
                        </div>
                        <div className='cursor-pointer flex items-center'>
                            <i className="fa-regular fa-user text-black bg-orange-400 py-2 px-2.5 rounded-3xl"></i>
                        </div>
                    </div>
               </div>
            </div>
        </div>
    )
}
