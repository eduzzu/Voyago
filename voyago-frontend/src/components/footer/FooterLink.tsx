export default function FooterLink({content}: {content: string}) {
  return (
    <p className="mb-1 cursor-pointer text-sm hover:text-red-700 hover:font-medium ">{content}</p>
  )
}
