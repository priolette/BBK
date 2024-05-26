"use client";

import {
  Pagination,
  PaginationContent,
  PaginationEllipsis,
  PaginationLink,
  PaginationNext,
  PaginationPrevious,
} from "@/components/ui/pagination";
import { usePathname, useRouter, useSearchParams } from "next/navigation";

type RecipePageProps = {
  itemCount: number;
  pageSize: number;
  currentPage: number;
};

export function RecipePagination({
  itemCount,
  pageSize,
  currentPage,
}: RecipePageProps) {
  const pathName = usePathname();
  const searchParams = useSearchParams();

  const pageCount = Math.ceil(itemCount / pageSize);
  const prevPage = currentPage > 1;
  const nextPage = currentPage < pageCount;

  if (pageCount <= 1) return null;

  const generatePagination = () => {
    const paginationLinks = [];
    const leftEllipsis = currentPage > 2;
    const rightEllipsis = currentPage < itemCount - 1;

    for (let i = 1; i <= itemCount; i++) {
      if (
        i === 1 ||
        i === pageCount ||
        (i >= currentPage - 1 && i <= currentPage + 1)
      ) {
        paginationLinks.push(
          <PaginationLink
            key={i}
            href={`${changePage(i)}`}
            isActive={i === currentPage}
          >
            {i}
          </PaginationLink>,
        );
      }
    }

    if (leftEllipsis) {
      paginationLinks.splice(1, 0, <PaginationEllipsis key="left" />);
    }
    if (rightEllipsis) {
      paginationLinks.splice(
        paginationLinks.length - 1,
        0,
        <PaginationEllipsis key="right" />,
      );
    }

    return paginationLinks;
  };

  const changePage = (page: number) => {
    const params = new URLSearchParams(searchParams);
    params.set("page", page.toString());
    return `${pathName}?${params.toString()}`;
  };

  return (
    <Pagination>
      <PaginationContent>
        {prevPage && (
          <PaginationPrevious
            href={`${changePage(currentPage - 1)}`}
          ></PaginationPrevious>
        )}
        {generatePagination()}
        {nextPage && (
          <PaginationNext
            href={`${changePage(currentPage + 1)}`}
          ></PaginationNext>
        )}
      </PaginationContent>
    </Pagination>
  );
}
