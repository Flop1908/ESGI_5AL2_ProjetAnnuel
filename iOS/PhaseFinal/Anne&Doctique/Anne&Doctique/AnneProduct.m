//
//  AnneProduct.m
//  MultiProductViewer
//
//  Created by JN on 2014-3-18.
//  Copyright (c) 2014 thoughtbot, inc. All rights reserved.
//

#import "AnneProduct.h"

@implementation AnneProduct

+ (instancetype)productWithDictionary:(NSDictionary *)dict {
    AnneProduct *product = [[self alloc] init];
    
    //NSTimeInterval longueur= *(NSTimeInterval) needle;
    //NSDate *dates = [NSDate dateWithTimeIntervalSince1970:*(NSTimeInterval)needle];
    
    if([dict[@"Type"] isEqual:@"VDM"]){
        product.author = dict[@"Author"];
        product.description = dict[@"Text"];
        product.nbcoms = dict[@"NbComments"];
        product.date= dict[@"Date"];
        product.votemoins = dict[@"Deserved"];
        product.voteplus = dict[@"Agree"];
        product.Id = dict[@"Id"];
        product.type = dict[@"Type"];
    }
    else if([dict[@"Type"] isEqual:@"DTC"]){
        product.author = @"";//ya pas
        product.description = dict[@"Text"];
        product.nbcoms = dict[@"NbComments"];
        product.date= dict[@"Date"];//ya pas
        product.votemoins = dict[@"Bad"];
        product.voteplus = dict[@"Good"];
        product.Id = dict[@"Id"];
        product.type = dict[@"Type"];
    }
    else if([dict[@"Type"] isEqual:@"CNF"]){
        product.author = @"";//ya pas
        product.description = dict[@"Text"];
        product.nbcoms = dict[@"NbComments"];
        product.date= dict[@"Date"];
        product.votemoins = @"";//ya pas
        product.point = dict[@"Points"];
        product.Id = dict[@"Id"];
        product.type = dict[@"Type"];
    }
    else
    {
        NSLog(@"there is no ref of it");
    }
    
    return product;
}


+ (NSArray *)productsWithArray:(NSArray *)array {
    NSMutableArray *products = [NSMutableArray arrayWithCapacity:[array count]];
    for (NSDictionary *dict in array) {
        AnneProduct *product = [self productWithDictionary:dict];
        [products addObject:product];
    }
    return products;
}


@end
