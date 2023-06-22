import Footer from '@/components/Footer'
import Header from '@/components/Header'
import { Inter } from 'next/font/google'
import './globals.css'

const inter = Inter({ subsets: ['latin'] })

export const metadata = {
  title: 'StarfallReact',
  description: 'Generated by create next app',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <div className='container'>
          <Header />
          {children}
          <Footer />
        </div>
      </body>
    </html>
  )
}
