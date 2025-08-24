import Footer from "../components/footer/Footer";
import Navbar from "../components/navbar/Navbar";

export default function Home() {
  return (
    <div className="w-full h-screen flex flex-col items-center">
      <Navbar />
      <Footer />
    </div>
  )
}
